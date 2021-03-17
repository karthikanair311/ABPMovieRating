using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
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

        public  void CreateRating(CreateRatingInput input)
        {
            //long currentUserId = _abpSession.UserId.Value;
            //var user = await _userManager.GetUserByIdAsync(currentUserId);
            //Console.Write(user);

            //var rating = new RatingDetails
            //{
            //    ReviewComments = input.ReviewComments,
            //    ReviewStar = input.ReviewStar,
            //    MovieId = input.MovieId,
            //   // CreatorUser = user
            //};

            //var rating = ObjectMapper.Map<RatingDetails>(input);

            var m = _ratingRepository.GetAll()
                .WhereIf(AbpSession.UserId != null, t => t.CreatorUserId == AbpSession.UserId)
                .Where(t => t.MovieId == input.MovieId)
                .Count();

            if (m >=1)
            {
                throw new Abp.UI.UserFriendlyException("Already the Movie has been Rated by you");

            }
            else
            {
                var rating = ObjectMapper.Map<RatingDetails>(input);
                _ratingRepository.InsertAsync(rating);

            }


            //await _ratingRepository.InsertAsync(rating);
        }
    }
}
