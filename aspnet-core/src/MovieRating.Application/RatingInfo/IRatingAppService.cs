using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MovieRating.RatingInfo.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRating.RatingInfo
{
    public interface IRatingAppService : IApplicationService
    {
        Task<ListResultDto<RatingListDto>> GetRating();
        Task<ListResultDto<RatingUserDto>> GetRatingUser(GetAllRatingInput input);
        //Task CreateRatingAsync(CreateRatingInput input);
        void CreateRating(CreateRatingInput input);
    }
}
