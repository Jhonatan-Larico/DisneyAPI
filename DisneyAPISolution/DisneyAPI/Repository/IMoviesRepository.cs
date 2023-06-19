using DisneyAPI.Domain.Entities;
using DisneyAPI.Dtos.Movies;
using DisneyAPI.Helpers;

namespace DisneyAPI.Repository
{
    public interface IMoviesRepository
    {
        Task<IEnumerable<MovieOrSerie>> GetMoviesAsync(MoviesResouceParameters moviesResouceParameters);

   
        Task<MovieOrSerie?> GetMovieAsync(Guid movieId);

        Task CreateMovie(MovieOrSerie movie);

        Task DeleteMovie(MovieOrSerie movieOrSerie);

        Task UpdateAsync();

        Task<bool> ExistMovie(MovieForCreationDto movie);

    }
}
