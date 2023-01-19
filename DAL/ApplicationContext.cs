using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Actor> Actors { get; set; } = null!;
        public DbSet<Film> Films { get; set; } = null!;
        public DbSet<Review> Reviews { get; set; } = null!;
        public DbSet<ActorFilm> ActorFilm { get; set; } = null!;

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActorFilm>().HasKey(u => new { u.ActorId, u.FilmId });
        }

    }
}
