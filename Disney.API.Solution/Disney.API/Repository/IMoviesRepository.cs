using Disney.API.Domain.Entities;
using Disney.API.Dtos.Movies;
using Disney.API.Helpers;

namespace Disney.API.Repository
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
