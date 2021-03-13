using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace MovieRating.EntityFrameworkCore
{
    public static class MovieRatingDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<MovieRatingDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<MovieRatingDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
