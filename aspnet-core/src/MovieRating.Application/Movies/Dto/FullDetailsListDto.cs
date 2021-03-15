using MovieRating.ActorInfo.Dto;
using MovieRating.RatingInfo.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRating.Movies.Dto
{
    public class FullDetailsListDto
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public DateTime ReleaseDate { get; set; }

        public RatingListDto RatingListDto { get; set; }
        public ActorListDto ActorListDto { get; set; }
    }
}
