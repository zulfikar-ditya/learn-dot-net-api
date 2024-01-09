using Interfaces.Repositories;
using PokemonReview.Data;
using PokemonReview.Models;

namespace Repositories
{
    public class ReviewerRepository: Repository<Reviewer>, ReviewerRepositoryInterface
    {
        private readonly DataContext _dataContext;
    
        public ReviewerRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public ICollection<Review> GetReviewsByReviewer(int ReviewerId)
        {
            return _dataContext.Reviews.Where(r => r.Reviewer.Id == ReviewerId).ToList();
        }
    }
}