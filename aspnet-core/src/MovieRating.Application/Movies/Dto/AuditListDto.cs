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
        //
        // Summary:
        //     Abp.Auditing.AuditInfo.ImpersonatorUserId.
        //public virtual long? ImpersonatorUserId { get; set; }
        //
        // Summary:
        //     Exception object, if an exception occured during execution of the method.
        public virtual string Exception { get; set; }
        //
        // Summary:
        //     Browser information if this method is called in a web request.
       // public virtual string BrowserInfo { get; set; }
        //
        // Summary:
        //     Name (generally computer name) of the client.
        //public virtual string ClientName { get; set; }
        //
        // Summary:
        //     IP address of the client.
        //public virtual string ClientIpAddress { get; set; }
        //
        // Summary:
        //     Total duration of the method call as milliseconds.
        public virtual int ExecutionDuration { get; set; }
        //
        // Summary:
        //     Return values.
        public virtual string ReturnValue { get; set; }
        //
        // Summary:
        //     TenantId.
       // public virtual int? TenantId { get; set; }
        //
        // Summary:
        //     Executed method name.
        public virtual string MethodName { get; set; }
        //
        // Summary:
        //     Service (class/interface) name.
        public virtual string ServiceName { get; set; }
        //
        // Summary:
        //     UserId.
        public virtual long? UserId { get; set; }
        //
        // Summary:
        //     Abp.Auditing.AuditInfo.ImpersonatorTenantId.
        //public virtual int? ImpersonatorTenantId { get; set; }
        //
        // Summary:
        //     Calling parameters.
        public virtual string Parameters { get; set; }
        //
        // Summary:
        //     Abp.Auditing.AuditInfo.CustomData.
        public virtual string CustomData { get; set; }
    }
}
