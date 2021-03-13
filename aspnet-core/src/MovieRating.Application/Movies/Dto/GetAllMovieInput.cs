using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static MovieRating.Movies.MovieDetails;

namespace MovieRating
{
    public class GetAllMovieInput : PagedResultRequestDto
    {
        public string Genre { get; set; }

        // public string Filter { get; set; }

    }
}