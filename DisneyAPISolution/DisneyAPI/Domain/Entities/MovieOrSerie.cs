using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DisneyAPI.Domain.Entities
{
    public class MovieOrSerie
    {
        [Key]
        public Guid Id { get; set; }

        [StringLength(200)]
        public string Title { get; set; }

        public DateTime CreationDate { get; set; }

        public int Rating { get; set; }

        public string ImageUrl { get; set; }

        [ForeignKey("Genre")]
        public Guid GenreId { get; set; }

        // Navigation property for the one-to-many relationship with Genre
        public Genre Genre { get; set; }

        // Navigation property for the many-to-many relationship with Character
        public List<Character> Characters { get; set; }

        //// Navigation property for the many-to-many relationship with Character
        //public virtual ICollection<CharacterMovieOrSerie> CharacterMovieOrSeries { get; set; }
    }
}
