using DisneyAPI.Domain.Entities;
using DisneyAPI.Dtos.Movies;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace DisneyAPI.Dtos.Character
{
    public class CharacterDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int? Age { get; set; }

        public float? Weight { get; set; }

        public string Story { get; set; }

        public string ImageUrl { get; set; }

        public List<MovieDto> MoviesOrSeries { get; set; }


    }
}
