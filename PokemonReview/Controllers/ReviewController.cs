using AutoMapper;
using Dtos;
using Interfaces.UnitOfWorks;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : Controller
    {
        public UnitOfWorkRepositoryInterface UnitOfWorkRepository;

        public IMapper Mapper;

        public ReviewController(UnitOfWorkRepositoryInterface unitOfWorkRepository, IMapper mapper)
        {
            UnitOfWorkRepository = unitOfWorkRepository;
            Mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ReviewDto>))]
        public IActionResult Index()
        {
            List<ReviewDto> reviews = Mapper.Map<List<ReviewDto>>(UnitOfWorkRepository.Review.GetAll());

            return Ok(reviews);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(ReviewDto))]
        public IActionResult Show(int id)
        {
            ReviewDto review = Mapper.Map<ReviewDto>(UnitOfWorkRepository.Review.Get(r => r.Id == id));

            return Ok(review);
        }

        [HttpGet("pokemon/{pokemonId}")]
        [ProducesResponseType(200, Type = typeof(List<ReviewDto>))]
        public IActionResult GetReviewsByPokemon(int pokemonId)
        {
            List<ReviewDto> reviews = Mapper.Map<List<ReviewDto>>(UnitOfWorkRepository.Review.GetReviewOfAPokemon(pokemonId));

            return Ok(reviews);
        }
    }
}