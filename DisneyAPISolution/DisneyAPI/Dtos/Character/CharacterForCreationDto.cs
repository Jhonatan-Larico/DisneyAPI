using System.ComponentModel.DataAnnotations;

namespace DisneyAPI.Dtos.Character
{
    public class CharacterForCreationDto : CharacterForManipulationDto
    {

        /// <summary>
        /// Story is Required
        /// </summary>
        [StringLength(200)]
        [Required(ErrorMessage = "The Story is required ")]
        public string Story { get; set; } = string.Empty;

        /// <summary>
        /// ImageUrl is Rquired
        /// </summary>
        [Required(ErrorMessage = "The ImageUrl is required ")]
        public string ImageUrl { get; set; } = string.Empty;


    }
}
