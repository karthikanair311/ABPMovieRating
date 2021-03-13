using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using MovieRating.Authorization.Users;
using MovieRating.RatingInfo.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRating.RatingInfo
{
    public class RatingAppService : MovieRatingAppServiceBase, IRatingAppService
    {
        private readonly IRepository<RatingDetails> _ratingRepository;
        private readonly UserManager _userManager;
        private readonly IAbpSession _abpSession;

        public RatingAppService(IRepository<RatingDetails> ratingRepository, UserManager userManager, IAbpSession abpSession)
        {
            _ratingRepository = ratingRepository;
            _userManager = userManager;
            _abpSession = abpSession;
        }

        public async Task<ListResultDto<RatingListDto>> GetRating()
        {
            var ratingdto = await _ratingRepository.GetAllListAsync();
            return new ListResultDto<RatingListDto>(ObjectMapper.Map<List<RatingListDto>>(ratingdto));
        }

        public  async Task CreateRatingAsync(CreateRatingInput input)
        {
            //long currentUserId = _abpSession.UserId.Value;
            //var user = await _userManager.GetUserByIdAsync(currentUserId);
            //Console.Write(user);
            
            var rating = new RatingDetails
            {
                ReviewComments = input.ReviewComments,
                ReviewStar = input.ReviewStar,
                MovieId = input.MovieId,
               // CreatorUser = user
            };
            //var rating = ObjectMapper.Map<RatingDetails>(input);
            await _ratingRepository.InsertAsync(rating);
        }
    }
}
