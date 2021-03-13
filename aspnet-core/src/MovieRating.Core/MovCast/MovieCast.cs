using Abp.Domain.Entities;
using MovieRating.ActorInfo;
using MovieRating.Movies;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRating.MovCast
{
    [Table("MovieCast")]
    public class MovieCast : Entity
    {
        public int MovieId { get; set; }
        [ForeignKey("MovieId")]
        public MovieDetails MovieDetails { get; set; }

        public int ActorId { get; set; }
        [ForeignKey("ActorId")]
        public ActorDetails ActorDetails { get; set; }
    }
}
