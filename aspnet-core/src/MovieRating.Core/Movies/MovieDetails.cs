using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieRating.Authorization.Users;
using MovieRating.MovCast;
using MovieRating.RatingInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRating.Movies
{
    [Table("Movie")]
    public class MovieDetails : Entity, IAudited
    {
        //  [ForeignKey("CreatorUserId")]
        // public User CreatorUser { get; set; }



    [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Title { get; set; }
        [Required]
        //[StringLength(15, MinimumLength = 3)]
        public GenreType Genre { get; set; }

        //    public List<SelectListItem> Genre { get; set; } = new List<SelectListItem>
        //{
        //    new SelectListItem { Value = "scific", Text = "Sci-Fic"},
        //    new SelectListItem { Value = "action", Text = "Action"},
        //    new SelectListItem { Value = "crime", Text = "Crime"},
        //    new SelectListItem { Value = "animation", Text = "Animation"},
        //    new SelectListItem { Value = "horror", Text = "Horror"},
        //    new SelectListItem { Value = "comedy", Text = "Comedy"}
        //};

        [Required]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public long? CreatorUserId { get ; set ; }
        [ForeignKey("CreatorUserId")]
        public User CreatorUser { get; set; }
        public DateTime CreationTime { get ; set ; }
        public long? LastModifierUserId { get ; set ; }
        public DateTime? LastModificationTime { get ; set ; }


        public ICollection<RatingDetails> MovieRatings { get; set; }

        public ICollection<MovieCast> CastList { get; set; }

    }
    public enum GenreType
    {
        SciFic,
        Action,
        Animation,
        Horror,
        Comedy,
        Crime

    }
}
