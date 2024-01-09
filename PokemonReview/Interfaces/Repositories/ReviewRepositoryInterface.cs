using PokemonReview.Models;

namespace Interfaces.Repositories
{
    public interface ReviewRepositoryInterface : RepositoryInterface<Review>
    {
        ICollection<Review> GetReviewOfAPokemon(int PokemonId);
    }
}