using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Disney.API.Dtos.Movies
{
    public class MovieForUpdateDto : MovieForManipulationDto
    {
        public int? Rating { get; set; }

        public string? ImageUrl { get; set; }

        public DateTime? CreationDate { get  ; set; }

    }
}
