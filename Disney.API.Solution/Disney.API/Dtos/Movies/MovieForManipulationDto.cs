using System.ComponentModel.DataAnnotations;

namespace Disney.API.Dtos.Movies
{
    public class MovieForManipulationDto
    {
        [StringLength(50)]
        [Required(ErrorMessage = "The Title is required")]
        public string Title { get; set; }
     
    }
}
