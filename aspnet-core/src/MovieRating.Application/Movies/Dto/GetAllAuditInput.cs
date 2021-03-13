using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRating.Movies.Dto
{
    public class GetAllAuditInput: PagedResultRequestDto
    {
        public string ApiName { get; set; }
    }
}
