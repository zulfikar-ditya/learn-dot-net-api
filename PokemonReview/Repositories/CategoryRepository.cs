using Interfaces.Repositories;
using PokemonReview.Data;
using PokemonReview.Models;

namespace Repositories
{
    public class CategoryRepository : Repository<Category>, CategoryRepositoryInterface
    {
        private readonly DataContext _dataContext;

        public CategoryRepository(DataContext dataContext) : base(dataContext)
        {
            // 
        }
    }
}