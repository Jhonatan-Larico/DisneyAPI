using System.ComponentModel.DataAnnotations;

namespace DisneyAPI.Dtos.Character
{

    public class CharacterForUpdateDto : CharacterForManipulationDto
    {

        /// <summary>
        /// Story may be nullable
        /// </summary>
        [StringLength(200)]
        public string? Story { get; set; }

        /// <summary>
        /// ImageUrl may be null
        /// </summary>
        public string? ImageUrl { get; set; }

    }
}
