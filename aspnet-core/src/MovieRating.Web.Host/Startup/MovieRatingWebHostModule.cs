using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MovieRating.Configuration;

namespace MovieRating.Web.Host.Startup
{
    [DependsOn(
       typeof(MovieRatingWebCoreModule))]
    public class MovieRatingWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public MovieRatingWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MovieRatingWebHostModule).GetAssembly());
        }
    }
}
