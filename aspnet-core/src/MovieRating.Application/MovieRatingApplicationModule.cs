using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MovieRating.ActorInfo.Dto;
using MovieRating.Authorization;
using MovieRating.MovCast;
using MovieRating.Movies;
using MovieRating.Movies.Dto;

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
                cfg => 
                {
                    
                    cfg.AddMaps(thisAssembly);
                    
                    cfg.CreateMap<MovieDetails, FullMovieDetailsListDto>()
                        .ForMember(dto => dto.CastList, options => options.Ignore())//MapFrom(input => input.CastList))
                        .ForMember(dto => dto.MovieRatings, options => options.MapFrom(input => input.MovieRatings));
                    //cfg.CreateMap<MovieCast, ActorListDto>().IncludeMembers(s =>s.ActorDetails)
                    //   .ForMember(dto => dto, options => options.MapFrom(input => input.ActorDetails));


                }
            );
        }
    }
}
