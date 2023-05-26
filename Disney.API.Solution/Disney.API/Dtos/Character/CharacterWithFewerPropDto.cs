using Disney.API.Domain.Entities;
using Disney.API.Dtos.Movies;
using System.ComponentModel.DataAnnotations;

namespace Disney.API.Dtos.Character
{
    public class CharacterWithFewerPropDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }
    }
}
