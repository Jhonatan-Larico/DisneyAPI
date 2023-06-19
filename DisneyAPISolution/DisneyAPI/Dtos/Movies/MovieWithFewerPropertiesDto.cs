namespace DisneyAPI.Dtos.Movies
{
    public class MovieWithFewerPropertiesDto
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public DateTime CreationDate { get; set; }

        public string ImageUrl { get; set; }
    }
}
