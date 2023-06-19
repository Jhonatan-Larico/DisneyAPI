using System.ComponentModel.DataAnnotations;

namespace DisneyAPI.Dtos.Movies
{
    public class MovieForCreationDto : MovieForManipulationDto
    {   

        public DateTime CreationDate { get; set; }

        public int Rating { get; set; }

        public string ImageUrl { get; set; }

        //Foreign Key
        [Required(ErrorMessage = "The GenreId is required ")]
        public Guid GenreId { get; set; }

    }
}
