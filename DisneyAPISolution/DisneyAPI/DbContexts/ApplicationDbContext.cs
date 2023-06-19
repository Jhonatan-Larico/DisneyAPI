using DisneyAPI.Domain.Entities;
using DisneyAPI.IdentyEntities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DisneyAPI.DbContexts
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Character> Character { get; set; }
        public DbSet<MovieOrSerie> MoviesOrSerie { get; set; }
        public DbSet<Genre> Genre { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MovieOrSerie>()
                .HasMany(m => m.Characters)
                .WithMany(c => c.MoviesOrSeries)
                .UsingEntity(j => j.ToTable("MovieOrSerieCharacter"));

            // Configure seed data
            var animationGenreId = Guid.NewGuid();
            var fantasyGenreId = Guid.NewGuid();
            var familyGenreId = Guid.NewGuid();
            var holidayGenreId = Guid.NewGuid();


            modelBuilder.Entity<Genre>().HasData(
                new Genre { Id = animationGenreId, Name = "Animation", ImageUrl = "https://example.com/animation.jpg" },
                new Genre { Id = fantasyGenreId, Name = "Fantasy", ImageUrl = "https://example.com/fantasy.jpg" },
                new Genre { Id = familyGenreId, Name = "Family", ImageUrl = "https://example.com/family.jpg" },
                new Genre { Id = holidayGenreId, Name = "Holiday", ImageUrl = "https://example.com/holiday.jpg" }
            );

            modelBuilder.Entity<Character>().HasData(
                new Character { Id = Guid.NewGuid(), Name = "Mickey Mouse", Age = 92, Weight = 23.5f, Story = "Mickey Mouse is the iconic and beloved character in Disney's cartoons.", ImageUrl = "https://example.com/mickey-mouse.jpg" },
                new Character { Id = Guid.NewGuid(), Name = "Minnie Mouse", Age = 92, Weight = 21.4f, Story = "Minnie Mouse is Mickey Mouse's girlfriend and one of Disney's iconic characters.", ImageUrl = "https://example.com/minnie.jpg" }
       
            );

            modelBuilder.Entity<MovieOrSerie>().HasData(
                new MovieOrSerie { Id = Guid.NewGuid(), Title = "Steamboat Willie", CreationDate = new DateTime(1928, 11, 18), Rating = 8, ImageUrl = "https://example.com/steamboat-willie.jpg", GenreId = animationGenreId },
                new MovieOrSerie { Id = Guid.NewGuid(), Title = "Fantasia", CreationDate = new DateTime(1940, 11, 13), Rating = 7, ImageUrl = "https://example.com/fantasia.jpg", GenreId = fantasyGenreId },
                new MovieOrSerie { Id = Guid.NewGuid(), Title = "The Mickey Mouse Club", CreationDate = new DateTime(1955, 10, 3), Rating = 6, ImageUrl = "https://example.com/mickey-mouse-club.jpg", GenreId = familyGenreId },
                new MovieOrSerie { Id = Guid.NewGuid(), Title = "Mickey's Once Upon a Christmas", CreationDate = new DateTime(1999, 11, 9), Rating = 7, ImageUrl = "https://example.com/mickeys-once-upon-a-christmas.jpg", GenreId = holidayGenreId }              
            );
        }
    }
}
