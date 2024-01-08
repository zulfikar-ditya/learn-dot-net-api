using AutoMapper;
using Dtos;
using Interfaces.UnitOfWorks;
using Microsoft.AspNetCore.Mvc;
using PokemonReview.Models;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : Controller
    {
        private readonly UnitOfWorkRepositoryInterface _unitOfWork;
        private readonly IMapper _mapper;

        public PokemonController(UnitOfWorkRepositoryInterface unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]
        public IActionResult Index()
        {
            List<PokemonDto> pokemonData = _mapper.Map<List<PokemonDto>>(_unitOfWork.Pokemon.GetAll());

            return Ok(pokemonData);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Pokemon))]
        [ProducesResponseType(404)]
        public IActionResult Show(int id)
        {
            Pokemon pokemonData = _unitOfWork.Pokemon.GetPokemon(id);

            if (pokemonData == null)
            {
                return NotFound();
            }

            return Ok(pokemonData);
        }

        [HttpGet("name/{name}")]
        [ProducesResponseType(200, Type = typeof(Pokemon))]
        [ProducesResponseType(404)]
        public IActionResult GetPokemonByName(string name)
        {
            Pokemon pokemonData = _unitOfWork.Pokemon.GetPokemon(name);

            if (pokemonData == null)
            {
                return NotFound();
            }

            return Ok(pokemonData);
        }

        [HttpGet("rating/{id}")]
        [ProducesResponseType(200, Type = typeof(double))]
        [ProducesResponseType(404)]
        public IActionResult GetPokemonRating(int id)
        {
            double pokemonRating = _unitOfWork.Pokemon.GetPokemonRating(id);

            return Ok(pokemonRating);
        }

        [HttpGet("exist/{id}")]
        [ProducesResponseType(200, Type = typeof(bool))]
        [ProducesResponseType(404)]
        public IActionResult PokemonIsExist(int id)
        {
            bool pokemonIsExist = _unitOfWork.Pokemon.PokemonIsExist(id);

            if (!pokemonIsExist)
            {
                return NotFound();
            }

            return Ok(pokemonIsExist);
        }
    }
}   