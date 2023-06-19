using DisneyAPI.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DisneyAPI.Dtos.Character;
using DisneyAPI.Dtos.Genre;

namespace DisneyAPI.Dtos.Movies
{
    public class MovieDto
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public DateTime CreationDate { get; set; }

        public string ImageUrl { get; set; }


        public GenreDto Genre { get; set; }


    }
}
