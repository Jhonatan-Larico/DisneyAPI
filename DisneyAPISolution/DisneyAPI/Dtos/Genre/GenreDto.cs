using DisneyAPI.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace DisneyAPI.Dtos.Genre
{
    public class GenreDto
    {
        //[Key]
        //public Guid Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public string ImageUrl { get; set; }

        // Navigation property for the one-to-many relationship with MovieOrSerie
        //public IEnumerable<MovieOrSerie> MoviesOrSeries { get; set; }
    }
}
