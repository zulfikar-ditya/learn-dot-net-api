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

        public PokemonController(UnitOfWorkRepositoryInterface unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]
        public IActionResult Index()
        {
            IEnumerable<Pokemon> pokemonData = _unitOfWork.Pokemon.GetAll();

            return Ok(pokemonData);
        }
    }
}   