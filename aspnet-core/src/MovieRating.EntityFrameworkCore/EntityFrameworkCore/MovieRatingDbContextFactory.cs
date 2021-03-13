using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using MovieRating.Configuration;
using MovieRating.Web;

namespace MovieRating.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class MovieRatingDbContextFactory : IDesignTimeDbContextFactory<MovieRatingDbContext>
    {
        public MovieRatingDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<MovieRatingDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            MovieRatingDbContextConfigurer.Configure(builder, configuration.GetConnectionString(MovieRatingConsts.ConnectionStringName));

            return new MovieRatingDbContext(builder.Options);
        }
    }
}
