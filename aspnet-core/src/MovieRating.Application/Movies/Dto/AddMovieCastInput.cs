using Abp.AutoMapper;
using MovieRating.MovCast;

namespace MovieRating.Movies
{
    [AutoMapTo(typeof(MovieCast))]
    public class AddMovieCastInput
    {
        public int MovieId { get; set; }
        public int ActorId { get; set; }
    }
}