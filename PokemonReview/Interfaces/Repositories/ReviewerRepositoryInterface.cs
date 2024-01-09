using PokemonReview.Models;

namespace Interfaces.Repositories
{
    public interface ReviewerRepositoryInterface : RepositoryInterface<Reviewer>
    {
        ICollection<Review> GetReviewsByReviewer(int ReviewerId);
    }
}