using AutoMapper;
using Dtos;
using Interfaces.UnitOfWorks;
using Microsoft.AspNetCore.Mvc;
using PokemonReview.Models;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController :Controller
    {
        private readonly UnitOfWorkRepositoryInterface _unitOfWork;

        private readonly IMapper _mapper;

        public OwnerController(UnitOfWorkRepositoryInterface unitOfWorkRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWorkRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Owner>))]
        public IActionResult Index()
        {
            List<OwnerDto> ownerData = _mapper.Map<List<OwnerDto>>(_unitOfWork.Owner.GetAll());

            return Ok(ownerData);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Owner))]
        [ProducesResponseType(404)]
        public IActionResult Show(int id)
        {
            Owner ownerData = _unitOfWork.Owner.Get(o => o.Id == id);

            if (ownerData == null)
            {
                return NotFound();
            }

            return Ok(ownerData);
        }

        [HttpGet("owner/{pekemonId}")]
        [ProducesResponseType(200, Type = typeof(Owner))]
        [ProducesResponseType(404)]
        public IActionResult GetOwnerOfAPokemon(int pekemonId)
        {
            ICollection<Owner> ownerData = _unitOfWork.Owner.GetOwnerOfAPokemon(pekemonId);

            return Ok(ownerData);
        }

        [HttpGet("pokemon/{ownerId}")]
        [ProducesResponseType(200, Type = typeof(Pokemon))]
        [ProducesResponseType(404)]
        public IActionResult GetPokemonsByOwner(int ownerId)
        {
            ICollection<Pokemon> pokemonData = _unitOfWork.Owner.GetPokemonsByOwner(ownerId);

            return Ok(pokemonData);
        }
    }
}