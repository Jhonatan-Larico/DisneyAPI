using AutoMapper;
using DisneyAPI.Domain.Entities;
using DisneyAPI.Dtos.Character;
using DisneyAPI.Dtos.Genre;
using DisneyAPI.Dtos.Movies;

namespace DisneyAPI.Profiles
{
    public class CharacteProfile : Profile
    {
        public CharacteProfile()
        {   
            //Character
            CreateMap<Character, CharacterDto>();
            CreateMap<Character, CharacterWithFewerPropDto>();
            CreateMap<CharacterForCreationDto, Character>();
            CreateMap<CharacterForUpdateDto, Character>()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

            //Movie
            CreateMap<MovieOrSerie, MovieDto>();
            CreateMap<MovieOrSerie, MovieWithFewerPropertiesDto>();
            CreateMap<MovieForCreationDto, MovieOrSerie>();         
            CreateMap<MovieForUpdateDto, MovieOrSerie>()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
            //If src == null then mapping to dest
            //this code ensures that if the source value(int?) is null, the destination value(int) will be used instead.
            CreateMap<int?, int>().ConvertUsing((src, dest) => src ?? dest);


            //Genre
            CreateMap<Genre, GenreDto>();

            //CharacterMovie; join table
            CreateMap<MovieOrSerie, MovieCharacterDto>();
            CreateMap<Character, CharacterNavigationP>();

            CreateMap<Character, CharacterMovieDto>();
            CreateMap<MovieOrSerie, MovieNavigationP>();





        }
    }
}
