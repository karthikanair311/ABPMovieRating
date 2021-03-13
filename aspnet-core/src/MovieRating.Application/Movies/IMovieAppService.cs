using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MovieRating.Movies.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRating
{
   public interface IMovieAppService : IApplicationService
    {
        Task<PagedResultDto<AuditListDto>> GetAllAuditLogs(GetAllAuditInput input);

        void CreateMovie(CreateMovieInput input);

        void UpdateMovie(UpdateMovieInput input);

        Task DeleteMovie(DeleteMovieInput input);

        PagedResultDto<MovieListDto> GetMovieItems(GetAllMovieInput input);

    }
    
}
