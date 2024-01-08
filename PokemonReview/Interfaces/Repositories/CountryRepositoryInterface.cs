using PokemonReview.Models;

namespace Interfaces.Repositories
{
    public interface CountryRepositoryInterface : RepositoryInterface<Country>
    {
        Country GetCountryByOwner(int id);

        ICollection<Owner> GetOwnerFromACountry(int id);
    }
}