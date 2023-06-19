using AutoMapper;
using DisneyAPI.Domain.Entities;
using DisneyAPI.Dtos.Character;
using DisneyAPI.Dtos.Movies;
using DisneyAPI.Helpers;
using DisneyAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DisneyAPI.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMoviesRepository _moviesRepository;
        private readonly IMapper _mapper;

        public MoviesController(IMoviesRepository moviesRepository, IMapper mapper)
        {
            _moviesRepository = moviesRepository;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieWithFewerPropertiesDto>>> GetMovies([FromQuery] MoviesResouceParameters moviesResourceParameters)
        {
            IEnumerable<MovieOrSerie> charactersFromRepo = await _moviesRepository.GetMoviesAsync(moviesResourceParameters);


            return Ok(_mapper.Map<IEnumerable<MovieWithFewerPropertiesDto>>(charactersFromRepo));

        }

        [HttpGet("{movieId}", Name = "GetMovie")]
        public async Task<ActionResult<MovieCharacterDto>> GetMovie(Guid movieId)
        {
            MovieOrSerie? movieFromRepo = await _moviesRepository.GetMovieAsync(movieId);

            if (movieFromRepo == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<MovieCharacterDto>(movieFromRepo));

        }


        [HttpPost]
        public async Task<ActionResult<MovieDto>> CreateMovie([FromBody] MovieForCreationDto movieForCreationDto)
        {
            if (await _moviesRepository.ExistMovie(movieForCreationDto))
            {
                ModelState.AddModelError("ErrorMessages", "Movie already Exists!");
                return BadRequest(ModelState);
            }

            MovieOrSerie movieToCreate = _mapper.Map<MovieOrSerie>(movieForCreationDto);

            await _moviesRepository.CreateMovie(movieToCreate);

            MovieDto movieDto = _mapper.Map<MovieDto>(movieToCreate);

            return CreatedAtRoute("GetMovie", new { movieId = movieDto.Id }, movieDto);
        }

        [HttpDelete("{characterId}")]
        public async Task<IActionResult> DeleteMovie(Guid characterId)
        {
            MovieOrSerie? movieIdentity = await _moviesRepository.GetMovieAsync(characterId);

            if (movieIdentity == null)
            {
                return NotFound();
            } 

            await _moviesRepository.DeleteMovie(movieIdentity);

            return NoContent();
        }

        /// <summary>
        /// Updates a character, fields from "CharacterForUpdateDto" that are null not will be applied to the updated character, the actual fields will keep 
        /// </summary>
        /// <param name="villaId"></param>
        /// <param name="characterForUpdateDto"></param>
        /// <returns></returns>
        [HttpPut("{characterId}")]
        public async Task<IActionResult> UpdateMovie(Guid characterId, MovieForUpdateDto movieForUpdateDto)
        {
            MovieOrSerie? movieIdentity = await _moviesRepository.GetMovieAsync(characterId);

            if (movieIdentity == null)
            {
                return NotFound();
            }

            //Replacing values from characterForUpdateDto to  characterIdentity
            _mapper.Map(movieForUpdateDto, movieIdentity);

            await _moviesRepository.UpdateAsync();
            return NoContent();
        }
    }
}
