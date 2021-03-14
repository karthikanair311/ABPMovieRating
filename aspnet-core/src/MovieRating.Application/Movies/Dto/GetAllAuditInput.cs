using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRating.Movies.Dto
{
    //[AutoMapTo(typeof(AuditListDto))]
    public class GetAllAuditInput: PagedResultRequestDto
    {
        public string ApiName { get; set; }
    }
}
