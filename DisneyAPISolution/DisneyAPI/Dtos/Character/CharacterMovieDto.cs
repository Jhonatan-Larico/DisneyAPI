using DisneyAPI.Dtos.Genre;
using DisneyAPI.Dtos.Movies;

namespace DisneyAPI.Dtos.Character
{
    public class CharacterMovieDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int? Age { get; set; }

        public float? Weight { get; set; }

        public string Story { get; set; }

        public string ImageUrl { get; set; }

        public List<MovieNavigationP> MoviesOrSeries { get; set; }
    }

    public class MovieNavigationP
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public DateTime CreationDate { get; set; }

        public string ImageUrl { get; set; }


        public GenreDto Genre { get; set; }


    }
}
