using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRating.RatingInfo.Dto
{
    [AutoMapFrom(typeof(RatingDetails))]
    public class RatingListDto 
    {
        public string ReviewComments { get; set; }

     
        public int ReviewStar { get; set; }

        public int MovieId { get; set; }
    }
}
