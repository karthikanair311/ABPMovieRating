using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MovieRating.Authorization;

namespace MovieRating
{
    [DependsOn(
        typeof(MovieRatingCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class MovieRatingApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<MovieRatingAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(MovieRatingApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
