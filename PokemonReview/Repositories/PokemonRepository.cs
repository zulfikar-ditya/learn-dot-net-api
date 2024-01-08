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

        public Pokemon GetPokemon(int id)
        {
            return _dataContext.Pokemons.Where(u => u.Id == id).First();
        }

        public Pokemon GetPokemon(string name)
        {
            return _dataContext.Pokemons.Where(u => u.Name == name).First();
        }

        public ICollection<Pokemon> GetPokemonsByCategory(int id)
        {
            return _dataContext.PokemonCategories.Where(u => u.CategoryId == id).Select(s => s.Pokemon).ToList();
        }

        public double GetPokemonRating(int id)
        {
            IQueryable<Review> reviews = _dataContext.Reviews.Where(u => u.Pokemon.Id == id);

            if (reviews.Count() > 0) {
                return reviews.Average(u => u.Rating);
            }

            return 0;
        }

        public bool PokemonIsExist(int id)
        {
            return _dataContext.Pokemons.Any(u => u.Id == id);
        }
    }
}