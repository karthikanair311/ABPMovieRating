using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieRating.Movies;
using System;
using System.Collections.Generic;


namespace MovieRating
{
    [AutoMapFrom(typeof(MovieDetails))]
    public class MovieListDto : IEntityDto
    {
        public string Title { get; set; }
        public GenreType Genre { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Id { get ; set ; }
    }
}