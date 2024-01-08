using AutoMapper;
using Dtos;
using Interfaces.UnitOfWorks;
using Microsoft.AspNetCore.Mvc;
using PokemonReview.Models;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly UnitOfWorkRepositoryInterface _unitOfWork;

        private readonly IMapper _mapper;

        public CategoryController(UnitOfWorkRepositoryInterface unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Category>))]
        public IActionResult Index()
        {
            List<CategoryDto> categoryData = _mapper.Map<List<CategoryDto>>(_unitOfWork.Category.GetAll());

            return Ok(new JsonResult(new
            {
                categoryData = categoryData,
                message = "Success"
            }));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Category))]
        [ProducesResponseType(404)]
        public IActionResult Show(int id)
        {
            Category categoryData = _unitOfWork.Category.Get(c => c.Id == id);

            if (categoryData == null)
            {
                return NotFound();
            }

            return Ok(new JsonResult(new
            {
                categoryData = _mapper.Map<CategoryDto>(categoryData),
                message = "Success"
            }));
        }

        [HttpGet("{id}/pokemons")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]
        [ProducesResponseType(404)]
        public IActionResult GetPokemonsByCategoryId(int id)
        {
            Category categoryData = _unitOfWork.Category.Get(c => c.Id == id);

            if (categoryData == null)
            {
                return NotFound();
            }

            List<PokemonDto> pokemonData = _mapper.Map<List<PokemonDto>>(_unitOfWork.Pokemon.GetPokemonsByCategory(id));

            return Ok(new JsonResult(new
            {
                pokemonData = pokemonData,
                message = "Success"
            }));
        }
    }
}