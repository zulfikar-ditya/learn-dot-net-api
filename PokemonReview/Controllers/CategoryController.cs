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

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(422)]
        [ProducesResponseType(500)]
        public IActionResult Store([FromBody] CategoryDto categoryDto)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            Category categoryData = new Category();
            categoryData.Name = categoryDto.Name;

            _unitOfWork.Category.Create(categoryData);

            try
            {
                _unitOfWork.Category.Save();
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Internal server error");
            }


            return Created();
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

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(422)]
        [ProducesResponseType(500)]
        public IActionResult Update(int id, [FromBody] CategoryDto categoryDto)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            Category categoryData = _unitOfWork.Category.Get(c => c.Id == id);

            if (categoryData == null)
            {
                return NotFound();
            }

            categoryData.Name = categoryDto.Name;

            _unitOfWork.Category.Update(categoryData);

            try
            {
                _unitOfWork.Category.Save();
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Internal server error");
            }

            return NoContent();
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

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult Delete(int id)
        {
            Category categoryData = _unitOfWork.Category.Get(c => c.Id == id);

            if (categoryData == null)
            {
                return NotFound();
            }

            _unitOfWork.Category.Delete(categoryData);

            try
            {
                _unitOfWork.Category.Save();
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Internal server error");
            }

            return NoContent();
        }
    }
}