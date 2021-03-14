using Abp.AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MovieRating.Movies.MovieDetails;

namespace MovieRating.Movies.Dto
{
    [AutoMapTo(typeof(MovieDetails))]
    public class CreateMovieInput
    {
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Title { get; set; }
        [Required]
       /// [StringLength(15, MinimumLength = 3)]
        public GenreType Genre { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
    }
}
