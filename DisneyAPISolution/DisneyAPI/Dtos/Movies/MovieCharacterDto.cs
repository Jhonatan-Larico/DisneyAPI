using DisneyAPI.Dtos.Genre;

namespace DisneyAPI.Dtos.Movies
{
    public class MovieCharacterDto
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public DateTime CreationDate { get; set; }

        public int Rating { get; set; }

        public string ImageUrl { get; set; }

        public List<CharacterNavigationP> Characters { get; set; }

        public GenreDto Genre { get; set; }
    }

    public class CharacterNavigationP
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int? Age { get; set; }

        public float? Weight { get; set; }

        public string Story { get; set; }

        public string ImageUrl { get; set; }

    }


}
