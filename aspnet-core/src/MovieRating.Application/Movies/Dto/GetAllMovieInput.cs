using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieRating.Movies;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static MovieRating.Movies.MovieDetails;

namespace MovieRating
{
    public class GetAllMovieInput : PagedResultRequestDto
    {
        public GenreType Genre { get; set; }

        public string Filter { get; set; }

    }
}