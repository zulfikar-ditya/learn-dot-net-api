using PokemonReview.Models;

namespace Interfaces.Repositories
{
    public interface OwnerRepositoryInterface : RepositoryInterface<Owner>
    {
        ICollection<Owner> GetOwnerOfAPokemon(int PokemonId);

        ICollection<Pokemon> GetPokemonsByOwner(int OwnerId);
    }
}