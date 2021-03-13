using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRating.ActorInfo.Dto
{
    [AutoMapFrom(typeof(ActorDetails))]
    public class ActorListDto : IEntityDto
    {

        public string ActorName { get; set; }
        public string ActorGender { get; set; }
        public int Id { get ; set ; }
    }
}
