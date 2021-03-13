using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRating.ActorInfo.Dto
{
    [AutoMapTo(typeof(ActorDetails))]
    public class CreateActorInput
    {
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string ActorName { get; set; }

        [Required]
        [StringLength(6, MinimumLength = 4)]
        public string ActorGender { get; set; }


    }
}