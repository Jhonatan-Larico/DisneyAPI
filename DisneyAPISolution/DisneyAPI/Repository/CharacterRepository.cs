using DisneyAPI.DbContexts;
using DisneyAPI.Domain.Entities;
using DisneyAPI.Dtos.Character;
using DisneyAPI.Helpers;
using Microsoft.EntityFrameworkCore;

namespace DisneyAPI.Repository
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly ApplicationDbContext _db;

        public CharacterRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Character>> GetCharactersAsync(CharactersResourceParameters charactersResourceParameters)
        {   
            var collection = _db.Character.Include(e => e.MoviesOrSeries) as IQueryable<Character>;
            
            //Filtering
            if (charactersResourceParameters.Age > 0)
            {
                collection = collection.Where(c => c.Age == charactersResourceParameters.Age);
            }
            if (charactersResourceParameters.Weight > 0)
            {   
                var w = (int)charactersResourceParameters.Weight;
                collection = collection.Where(c => (int)c.Weight == w);
            }
            if (!string.IsNullOrWhiteSpace(charactersResourceParameters.MoviesOrSeries))
            {
                var movie = charactersResourceParameters.MoviesOrSeries.Trim();
                 collection = collection.Where(c => c.MoviesOrSeries.Any(m => m.Title == movie));
            }

            //Searching
            if (!string.IsNullOrWhiteSpace(charactersResourceParameters.Name))
            {
                var name = charactersResourceParameters.Name.Trim();
                collection = collection.Where(c => c.Name.Contains(name) );
            }

    

            return await collection.ToListAsync();
        }

        public async Task<Character?> GetCharacterAsync(Guid characterId)
        {
            Character? character = await _db.Character.Include(e => e.MoviesOrSeries).ThenInclude(e => e.Genre).FirstOrDefaultAsync(c => c.Id == characterId);

            return character;
        }

        public async Task CreateCharacter(Character character)
        {
            character.Id = Guid.NewGuid();
            _db.Character.Add(character);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteCharacter(Character character)
        {
            _db.Character.Remove(character);
            await _db.SaveChangesAsync();
        }

        public Task<bool> ExistCharacter(CharacterForCreationDto? character, Guid? characterId)
        {
            if (character != null)
            {
                return _db.Character.AnyAsync(c => c.Name == character.Name);

            }
            return _db.Character.AnyAsync(c => c.Id == characterId);

        }

        public async Task UpdateAsync()
        {
            await _db.SaveChangesAsync();
        }

        public async Task AddMovieToCharacter(MovieOrSerie movie, Character character)
        {
            character.MoviesOrSeries.Add(movie);
            await _db.SaveChangesAsync();
        }
    }
}
