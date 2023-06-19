using DisneyAPI.Domain.Entities;
using DisneyAPI.Dtos.Movies;
using System.ComponentModel.DataAnnotations;

namespace DisneyAPI.Dtos.Character
{
    public class CharacterWithFewerPropDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }
    }
}
