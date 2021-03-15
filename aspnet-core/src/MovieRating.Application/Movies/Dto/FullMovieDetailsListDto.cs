using Abp.AutoMapper;
using MovieRating.ActorInfo.Dto;
using MovieRating.RatingInfo.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRating.Movies.Dto
{
    [AutoMapFrom(typeof(MovieDetails))]
    public class FullMovieDetailsListDto
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public DateTime ReleaseDate { get; set; }
        //public string ActorName { get ; set; }
        //public string ActorGender { get; set; }

        public ICollection<RatingListDto> MovieRatings { get; set; }

        public ICollection<ActorListDto> CastList { get; set; }
    }
}
