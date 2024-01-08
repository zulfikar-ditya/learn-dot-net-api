namespace Repositories
{
    using PokemonReview.Models;
    using Interfaces.Repositories;
    using PokemonReview.Data;
    using System.Runtime.CompilerServices;

    public class CountryRepository : Repository<Country>, CountryRepositoryInterface
    {
        private readonly DataContext _dataContext;

        public CountryRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public Country GetCountryByOwner(int id)
        {
            return _dataContext.Owners.Where(u => u.Id == id).Select(c => c.Country).FirstOrDefault();
        }

        public ICollection<Owner> GetOwnerFromACountry(int id)
        {
            return _dataContext.Owners.Where(u => u.Country.Id == id).ToList();
        }
    }
}