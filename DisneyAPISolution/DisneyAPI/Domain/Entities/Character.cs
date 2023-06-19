using System.ComponentModel.DataAnnotations;

namespace DisneyAPI.Domain.Entities
{
    public class Character
    {
        [Key]
        public Guid Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public int? Age { get; set; }

        public float? Weight { get; set; }

        [StringLength(200)]
        public string Story { get; set; }

        public string ImageUrl { get; set; }

        // Navigation property for the many-to-many relationship with MovieOrSerie
        public List<MovieOrSerie> MoviesOrSeries { get; set; }
    }
}
