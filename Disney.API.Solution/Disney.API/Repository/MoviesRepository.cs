using AutoMapper;
using Disney.API.Controllers;
using Disney.API.DbContexts;
using Disney.API.Domain.Entities;
using Disney.API.Dtos.Character;
using Disney.API.Dtos.Movies;
using Disney.API.Helpers;
using Disney.API.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Disney.API.Repository
{
    public class MoviesRepository : IMoviesRepository
    {
        private readonly ApplicationDbContext _db;

        public MoviesRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<MovieOrSerie>> GetMoviesAsync(MoviesResouceParameters moviesResourceParameters)
        {
            var collection = _db.MoviesOrSerie.Include(m => m.Genre) as IQueryable<MovieOrSerie>;


            if (moviesResourceParameters.CreationDate == "DES")
            {
                collection = collection.OrderByDescending(c => c.CreationDate);
            }
            else collection = collection.OrderBy(c => c.CreationDate);


            //Fintering
            if (!string.IsNullOrWhiteSpace(moviesResourceParameters.Genre))
            {
                var genre = moviesResourceParameters.Genre.Trim();
                collection = collection.Where(c => c.Genre.Name ==genre );
            }

            //Searching
            if (!string.IsNullOrWhiteSpace(moviesResourceParameters.Title))
            {
                var title = moviesResourceParameters.Title.Trim();
                collection = collection.Where(c => c.Title.Contains(title));
            }        

            return await collection.ToListAsync();
        }

        public async Task<MovieOrSerie?> GetMovieAsync(Guid characterId)
        {
            MovieOrSerie? movie = await _db.MoviesOrSerie.Include(m => m.Characters).Include(m => m.Genre).FirstOrDefaultAsync(c => c.Id == characterId);

            return movie;
        }

        public async Task CreateMovie(MovieOrSerie movie)
        {
            movie.Id = Guid.NewGuid();
            _db.MoviesOrSerie.Add(movie);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteMovie(MovieOrSerie movie)
        {
            _db.MoviesOrSerie.Remove(movie);
            await _db.SaveChangesAsync();
        }

        public Task<bool> ExistMovie(MovieForCreationDto movie)
        {
            return _db.MoviesOrSerie.AnyAsync(c => c.Title == movie.Title);
        }

        public async Task UpdateAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}


