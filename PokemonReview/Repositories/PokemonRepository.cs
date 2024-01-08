using Interfaces.Repositories;
using PokemonReview.Data;
using PokemonReview.Models;

namespace Repositories
{
    public class PokemonRepository : Repository<Pokemon>, PokemonRepositoryInterface
    {
        private readonly DataContext _dataContext;

        public PokemonRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }
    }
}