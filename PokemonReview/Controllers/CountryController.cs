using Microsoft.AspNetCore.Mvc;
using Interfaces.UnitOfWorks;
using PokemonReview.Models;
using AutoMapper;
using Dtos;

namespace Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CountryController : ControllerBase
    {
        private readonly UnitOfWorkRepositoryInterface _unitOfWork;

        private readonly IMapper _mapper;

        public CountryController(UnitOfWorkRepositoryInterface unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CountryDto>))]
        public IActionResult Index()
        {
            ICollection<CountryDto> countries =  _mapper.Map<List<CountryDto>>(_unitOfWork.Country.GetAll());

            return Ok(countries);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(CountryDto))]
        public IActionResult Show(int id)
        {
            var country = _mapper.Map<CountryDto>(_unitOfWork.Country.Get(u => u.Id == id));

            return Ok(country);
        }

        [HttpGet("{id}/owners")]
        [ProducesResponseType(200, Type = typeof(List<OwnerDto>))]
        public IActionResult GetOwnerFromACountry(int id)
        {
            var owners = _mapper.Map<List<OwnerDto>>(_unitOfWork.Country.GetOwnerFromACountry(id));

            return Ok(owners);
        }

        [HttpGet("{ownerId}/owner")]
        [ProducesResponseType(200, Type = typeof(CountryDto))]
        public IActionResult GetCountryByOwner(int ownerId)
        {
            var country = _mapper.Map<CountryDto>(_unitOfWork.Country.GetCountryByOwner(ownerId));

            return Ok(country);
        }
    }
}