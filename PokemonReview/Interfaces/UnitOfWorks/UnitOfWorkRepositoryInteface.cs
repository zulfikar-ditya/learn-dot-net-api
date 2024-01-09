using Interfaces.Repositories;

namespace Interfaces.UnitOfWorks
{
    public interface UnitOfWorkRepositoryInterface
    {
        PokemonRepositoryInterface Pokemon { get; }

        CategoryRepositoryInterface Category { get; }

        CountryRepositoryInterface Country { get; }

        OwnerRepositoryInterface Owner { get; }

        ReviewRepositoryInterface Review { get; }

        ReviewerRepositoryInterface Reviewer { get; }
    }
}