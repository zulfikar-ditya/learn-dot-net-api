using AutoMapper;
using Dtos;
using Interfaces.UnitOfWorks;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewerController :Controller
    {
        private readonly UnitOfWorkRepositoryInterface _unitOfWorkRepository;
        private readonly IMapper _mapper;

        public ReviewerController(UnitOfWorkRepositoryInterface unitOfWorkRepository, IMapper mapper)
        {
            _unitOfWorkRepository = unitOfWorkRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ReviewerDto>))]
        public IActionResult Index()
        {
            List<ReviewerDto> reviewerData = _mapper.Map<List<ReviewerDto>>(_unitOfWorkRepository.Reviewer.GetAll());

            return Ok(reviewerData);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(ReviewerDto))]
        [ProducesResponseType(404)]
        public IActionResult Show(int id)
        {
            ReviewerDto reviewerData = _mapper.Map<ReviewerDto>(_unitOfWorkRepository.Reviewer.Get(r => r.Id == id));

            if (reviewerData == null)
            {
                return NotFound();
            }

            return Ok(reviewerData);
        }

        [HttpGet("{reviewId}/reviews")]
        [ProducesResponseType(200, Type = typeof(ReviewerDto))]
        [ProducesResponseType(404)]
        public IActionResult GetReviewsByReviewer(int reviewId)
        {
            ICollection<ReviewerDto> reviewerData = _mapper.Map<ICollection<ReviewerDto>>(_unitOfWorkRepository.Reviewer.GetReviewsByReviewer(reviewId));

            return Ok(reviewerData);
        }
    }
}