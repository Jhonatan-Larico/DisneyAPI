using Disney.API.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Disney.API.Dtos.Character;
using Disney.API.Dtos.Genre;

namespace Disney.API.Dtos.Movies
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
