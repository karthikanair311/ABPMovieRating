using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using MovieRating.Authorization.Roles;
using MovieRating.Authorization.Users;
using MovieRating.MultiTenancy;
using MovieRating.Movies;
using MovieRating.ActorInfo;
using MovieRating.MovCast;
using MovieRating.RatingInfo;

namespace MovieRating.EntityFrameworkCore
{
    public class MovieRatingDbContext : AbpZeroDbContext<Tenant, Role, User, MovieRatingDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public MovieRatingDbContext(DbContextOptions<MovieRatingDbContext> options)
            : base(options)
        {
        }
        public DbSet<MovieDetails> Movies { get; set; }
        public DbSet<ActorDetails> Actors { get; set; }
        public DbSet<MovieCast> Casts { get; set; }
        public DbSet<RatingDetails> Ratings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<MovieDetails>().Property(p => p.Genre).HasDefaultValue(GenreType.Action);
        }
    }
}
