using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using MovieRating.Authorization.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRating.ActorInfo
{
    [Table("Actor")]
    public class ActorDetails : Entity , IAudited
    {
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string ActorName { get; set; }

        [Required]
        [StringLength(6, MinimumLength = 4)]
        public string ActorGender { get; set; }
        public long? CreatorUserId { get; set; }
        [ForeignKey("CreatorUserId")]
        public User CreatorUser { get; set; }
        public DateTime CreationTime { get; set; }
        public long? LastModifierUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }


    }
}
