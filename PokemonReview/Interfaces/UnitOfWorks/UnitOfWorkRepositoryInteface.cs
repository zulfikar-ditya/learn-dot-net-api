using Interfaces.Repositories;

namespace Interfaces.UnitOfWorks
{
    public interface UnitOfWorkRepositoryInterface
    {
        PokemonRepositoryInterface Pokemon { get; }
    }
}