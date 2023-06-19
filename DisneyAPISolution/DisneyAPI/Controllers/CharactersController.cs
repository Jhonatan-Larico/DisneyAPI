using AutoMapper;
using DisneyAPI.Domain.Entities;
using DisneyAPI.Dtos.Character;
using DisneyAPI.Helpers;
using DisneyAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace DisneyAPI.Controllers
{
    [Route("api/characters")]
    //[Authorize(Roles = "User, Admin")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private readonly ICharacterRepository _characterRepository;
        private readonly IMapper _mapper;
        private readonly IMoviesRepository _moviesRepository;

        public CharactersController(ICharacterRepository characterRepository, IMapper mapper, IMoviesRepository moviesRepository)
        {
            _characterRepository = characterRepository;
            _mapper = mapper;
            _moviesRepository = moviesRepository;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CharacterWithFewerPropDto>>> GetCharacters([FromQuery] CharactersResourceParameters charactersResourceParameters)
        {
            IEnumerable<Character> charactersFromRepo = await _characterRepository.GetCharactersAsync(charactersResourceParameters);


            return Ok(_mapper.Map<IEnumerable<CharacterWithFewerPropDto>>(charactersFromRepo));

        }

        [HttpGet("{characterId}", Name = "GetCharacter")]
        public async Task<ActionResult<CharacterMovieDto>> GetCharacter(Guid characterId)
        {
            Character? characterFromRepo = await _characterRepository.GetCharacterAsync(characterId);

            if (characterFromRepo == null)
            {
                return NotFound();
            }
            var a = _mapper.Map<CharacterMovieDto>(characterFromRepo);

            return Ok(a);

        }

        [HttpPost]
        public async Task<ActionResult<CharacterDto>> CreateCharacter([FromBody] CharacterForCreationDto characterForCreationDto)
        {
            if (await _characterRepository.ExistCharacter(characterForCreationDto, null))
            {
                ModelState.AddModelError("ErrorMessages", "Character already Exists!");
                return BadRequest(ModelState);
            }

            Character characterToCreate = _mapper.Map<Character>(characterForCreationDto);

            await _characterRepository.CreateCharacter(characterToCreate);

            CharacterDto characterDto = _mapper.Map<CharacterDto>(characterToCreate);

            return CreatedAtRoute("GetCharacter", new { characterId = characterDto.Id }, characterDto);
        }

        [HttpPost("{characterId}/movies/{movieId}")]
        public async Task<ActionResult<CharacterMovieDto>> AddMovieToCharacter(Guid characterId, Guid movieId)
        {      
            Character? characterFromRepo = await _characterRepository.GetCharacterAsync(characterId);      
            MovieOrSerie? movieFromRepo = await _moviesRepository.GetMovieAsync(movieId);

            if (movieFromRepo == null || characterFromRepo == null)
            {
                return NotFound();
            }

            await _characterRepository.AddMovieToCharacter(movieFromRepo, characterFromRepo);     

            return Ok(_mapper.Map<CharacterMovieDto>(characterFromRepo));
        }


        [HttpDelete("{characterId}")]
        public async Task<IActionResult> DeleteCharacter(Guid characterId)
        {
            Character? characterIdentity  = await _characterRepository.GetCharacterAsync(characterId);

            if (characterIdentity == null)
            {
                return NotFound();
            }

            await _characterRepository.DeleteCharacter(characterIdentity);

            return NoContent();
        }

        /// <summary>
        /// Updates a character, fields from "CharacterForUpdateDto" that are null not will be applied to the updated character, the actual fields will keep 
        /// </summary>
        /// <param name="villaId"></param>
        /// <param name="characterForUpdateDto"></param>
        /// <returns></returns>
        [HttpPut("{villaId}")]
        public async Task<IActionResult> UpdateCharacter(Guid villaId, CharacterForUpdateDto characterForUpdateDto)
        {
            Character? characterIdentity = await _characterRepository.GetCharacterAsync(villaId);

            if (characterIdentity == null)
            {
                return NotFound();
            }

            //Replacing values from characterForUpdateDto to  characterIdentity
            _mapper.Map(characterForUpdateDto, characterIdentity);

            await _characterRepository.UpdateAsync();
            return NoContent();
        }


    }
}
