using Interfaces.Repositories;
using PokemonReview.Data;
using PokemonReview.Models;

namespace Repositories
{
    public class ReviewRepository : Repository<Review>, ReviewRepositoryInterface
    {
        private readonly DataContext _dataContext;

        public ReviewRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public ICollection<Review> GetReviewOfAPokemon(int PokemonId)
        {
            return _dataContext.Reviews.Where(p => p.PokemonId == PokemonId).ToList();
        }
    }
}