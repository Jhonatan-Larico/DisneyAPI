using DisneyAPI.Domain.Entities;
using DisneyAPI.Dtos.Character;
using DisneyAPI.Helpers;

namespace DisneyAPI.Repository
{
    public interface ICharacterRepository
    {

        Task<IEnumerable<Character>> GetCharactersAsync(CharactersResourceParameters charactersResourceParameters);

        /// <summary>
        /// Get  a character with the related movies or series
        /// </summary>
        /// <param name="characterId"></param>
        /// <returns></returns>
        Task<Character?> GetCharacterAsync(Guid characterId);

        Task CreateCharacter(Character character);

        Task DeleteCharacter(Character character);

        Task UpdateAsync();

        Task<bool> ExistCharacter(CharacterForCreationDto? character , Guid? characterId);

        Task AddMovieToCharacter(MovieOrSerie movie, Character character);




    }
}
