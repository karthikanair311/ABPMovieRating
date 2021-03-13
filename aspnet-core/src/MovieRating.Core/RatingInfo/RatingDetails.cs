using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using MovieRating.Authorization.Users;
using MovieRating.Movies;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRating.RatingInfo
{
    [Table("Rating")]
    public class RatingDetails : Entity , IAudited
    {
        public string ReviewComments { get; set; }
        
        [Range(1,5)]
        public int ReviewStar { get; set; }

        public int MovieId { get; set; }
        [ForeignKey("MovieId")]
        public MovieDetails MovieDetails { get; set; }
        [Required]
       
        public long? CreatorUserId { get ; set ; }
        [ForeignKey("CreatorUserId")]
        public User CreatorUser { get; set; }
        public DateTime CreationTime { get ; set ; }
        public long? LastModifierUserId { get ; set ; }
        public DateTime? LastModificationTime { get ; set ; }
    }
}
