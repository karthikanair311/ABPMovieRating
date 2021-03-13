using Abp.AutoMapper;
using MovieRating.Authorization.Users;
using MovieRating.Movies;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRating.RatingInfo.Dto
{
    [AutoMapTo(typeof(RatingDetails))]

    public class CreateRatingInput
    {
        public string ReviewComments { get; set; }

        [Range(1, 5)]
        public int ReviewStar { get; set; }

        public int MovieId { get; set; }
        //[ForeignKey("MovieId")]
        //public MovieDetails MovieDetails { get; set; }
       // public int CreatorUserId { get; set; }
        // public User CreatorUser { get; set; }
    }
}
