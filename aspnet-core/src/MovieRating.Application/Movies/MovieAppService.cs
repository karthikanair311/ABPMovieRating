using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;
using Abp.Authorization;
using MovieRating.Movies.Dto;
using System.Linq;
using Abp.Auditing;
using MovieRating.MovCast;
using MovieRating.ActorInfo.Dto;

namespace MovieRating.Movies
{
    //[AbpAuthorize("Administration.UserManagement.CreateUser")]
    public class MovieAppService : MovieRatingAppServiceBase, IMovieAppService
    {
        private readonly IRepository<MovieDetails> _movieRepository;
        private readonly IRepository<AuditLog, long> _auditlogRepository;



        public MovieAppService(IRepository<MovieDetails> movieRepository, IRepository<AuditLog, long> auditlogRepository)
        {
            _movieRepository = movieRepository;
            _auditlogRepository = auditlogRepository;
        }

        public async Task<PagedResultDto<AuditListDto>> GetAllAuditLogs(GetAllAuditInput input)
        {
            var auditQuery = _auditlogRepository.GetAll()
                .WhereIf(!input.ApiName.IsNullOrEmpty(), t => t.MethodName == input.ApiName); //.ToListAsync()

            var pagedResult = await auditQuery.OrderByDescending(p => p.Id)
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount)
                .ToListAsync();

            var totalcount = auditQuery.Count();

            var auditLogMapped = ObjectMapper.Map<List<AuditListDto>>(pagedResult);
            return new PagedResultDto<AuditListDto>(totalcount, auditLogMapped); 
        }

        public void CreateMovie(CreateMovieInput input)
        {
            //var movie = _objectMapper.Map<MovieDetails>(input);
            var movie = ObjectMapper.Map<MovieDetails>(input);
            //var movie = new MovieDetails { Title = input.Title, Genre = input.Genre, ReleaseDate = input.ReleaseDate };
            _movieRepository.Insert(movie);
        }

        public async Task AddMovieCastAsync(AddMovieCastInput input)
        {
            //var movie = _objectMapper.Map<MovieDetails>(input);
            var movieData = await _movieRepository.GetAllIncluding(p => p.CastList).FirstOrDefaultAsync(m => m.Id == input.MovieId);
            if (movieData.CastList.Count(p =>p.ActorId == input.ActorId) != 0)
            {
                throw new Abp.UI.UserFriendlyException("Actor already part of Movie Cast");
            }
            
            
            var movieCast = ObjectMapper.Map<MovieCast>(input);

            movieData.CastList.Add(movieCast);
            //var movie = new MovieDetails { Title = input.Title, Genre = input.Genre, ReleaseDate = input.ReleaseDate };
            await _movieRepository.UpdateAsync(movieData);
        }

        public void UpdateMovie(UpdateMovieInput input)
        {
            var movie = _movieRepository.Get(input.Id);
            ObjectMapper.Map(input, movie);

        }

        public async Task DeleteMovie(DeleteMovieInput input)
        {
            await _movieRepository.DeleteAsync(input.Id);
        }

        public PagedResultDto<MovieListDto> GetMovieItems(GetAllMovieInput input)
        {
            var movieQuery = _movieRepository.GetAll().WhereIf(!input.Genre.IsNullOrEmpty(), t => t.Genre.Contains(input.Genre));

            var pagedResult = movieQuery.OrderBy(p => p.Genre).Skip(input.SkipCount).Take(input.MaxResultCount).ToList();

            var totalcount = movieQuery.Count();

            var moviemapped = ObjectMapper.Map<List<MovieListDto>>(pagedResult);
            return new PagedResultDto<MovieListDto>(totalcount, moviemapped);


        }



        public async Task< FullMovieDetailsListDto> GetMovieDetails(EntityDto<int> input)
        {
            var movieData = await _movieRepository
                .GetAllIncluding(p => p.MovieRatings)
                .Include(m => m.CastList).ThenInclude(n => n.ActorDetails)
                .FirstOrDefaultAsync(m => m.Id == input.Id)
                ;
            var movieDto =  ObjectMapper.Map<FullMovieDetailsListDto>(movieData);
            var actorDetails = movieData.CastList.Select(t => t.ActorDetails);
            movieDto.CastList = ObjectMapper.Map<List<ActorListDto>>(actorDetails);
            return movieDto;
            //return new ListResultDto<FullMovieDetailsListDto>(movieDto);
            //.Select(p => new FullMovieDetailsListDto{ })

            //.Include(p => p.MovieRating)

        }
    }
}
