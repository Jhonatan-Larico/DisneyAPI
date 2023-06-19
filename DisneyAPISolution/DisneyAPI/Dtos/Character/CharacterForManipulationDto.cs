using DisneyAPI.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace DisneyAPI.Dtos.Character
{
    public abstract class CharacterForManipulationDto
    {
        /// <summary>
        /// Name is Required
        /// </summary>
        [StringLength(50)]
        [Required(ErrorMessage = "The Name is required")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Age may be nullable
        /// </summary>
        public int? Age { get; set; }

        /// <summary>
        /// Weight may be nullable
        /// </summary>
        public float? Weight { get; set; }



    }
}
