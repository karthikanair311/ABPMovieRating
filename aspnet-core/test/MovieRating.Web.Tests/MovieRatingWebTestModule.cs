using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MovieRating.EntityFrameworkCore;
using MovieRating.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace MovieRating.Web.Tests
{
    [DependsOn(
        typeof(MovieRatingWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class MovieRatingWebTestModule : AbpModule
    {
        public MovieRatingWebTestModule(MovieRatingEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MovieRatingWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(MovieRatingWebMvcModule).Assembly);
        }
    }
}