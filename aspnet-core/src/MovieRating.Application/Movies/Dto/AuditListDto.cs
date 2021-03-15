using Abp.Auditing;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRating.Movies.Dto
{
    [AutoMapFrom(typeof(AuditLog))]
    public class AuditListDto
    {
        public virtual DateTime ExecutionTime { get; set; }
        public virtual string Exception { get; set; }
        public virtual int ExecutionDuration { get; set; }
        public virtual string ReturnValue { get; set; }
        public virtual string MethodName { get; set; }
        public virtual string ServiceName { get; set; }
        public virtual long? UserId { get; set; }
        public virtual string CustomData { get; set; }
    }
}
