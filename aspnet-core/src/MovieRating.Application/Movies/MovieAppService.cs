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
using System;

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
                .WhereIf (! input.ApiName.IsNullOrEmpty(), t => t.MethodName == input.ApiName)
                //.ToListAsync()
                ;


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
            // var movieQuery = _movieRepository.GetAll().WhereIf(!input.Genre.IsNullOrEmpty(), t => t.Genre.ToString().Contains(input.Genre));
            var movieQuery = _movieRepository.GetAll().Where(t => t.Genre == input.Genre)
                .WhereIf(!input.Filter.IsNullOrEmpty(), t =>// t.Genre.ToString().Contains(input.Filter)|| 
                t.Title.Contains(input.Filter)); //Contains(input.Genre));

            var pagedResult = movieQuery.OrderBy(p => p.Genre).Skip(input.SkipCount).Take(input.MaxResultCount).ToList();

            var totalcount = movieQuery.Count();

            var moviemapped = ObjectMapper.Map<List<MovieListDto>>(pagedResult);
            return new PagedResultDto<MovieListDto>(totalcount, moviemapped);


        }
        public  List<NameValueDto<int>> GetAllGenreTypes()
        {
            var genreList  = Enum.GetValues(typeof(GenreType)).Cast<GenreType>().Select(t => new NameValueDto<int>
            {
                Name = t.ToString(),
                Value = (int)t
            })
                .ToList();
            //SELECT(T => new NameValueDto<int> { Name = t.ToString(), Value = (int)t }
            //NameValueDto<int> abc;
            //abc.
            return genreList;

        }
    }
}
