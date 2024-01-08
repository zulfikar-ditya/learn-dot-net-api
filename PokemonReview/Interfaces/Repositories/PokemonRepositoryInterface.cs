using PokemonReview.Models;

namespace Interfaces.Repositories
{
    public interface PokemonRepositoryInterface : RepositoryInterface<Pokemon>
    {
        Pokemon GetPokemon(int id);

        Pokemon GetPokemon(string name);

        ICollection<Pokemon> GetPokemonsByCategory(int id);

        double GetPokemonRating(int id);

        bool PokemonIsExist(int id);
    }
}