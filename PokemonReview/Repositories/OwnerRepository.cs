using AutoMapper;
using Interfaces.Repositories;
using PokemonReview.Data;
using PokemonReview.Models;

namespace Repositories
{
    public class OwnerRepository : Repository<Owner>, OwnerRepositoryInterface
    {
        private readonly DataContext _dataContext;

        public OwnerRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public ICollection<Owner> GetOwnerOfAPokemon(int PokemonId)
        {
            return _dataContext.PokemonOwners.Where(p => p.PokemonId == PokemonId).Select(s => s.Owner).ToList();
        }

        public ICollection<Pokemon> GetPokemonsByOwner(int OwnerId)
        {
            return _dataContext.PokemonOwners.Where(o => o.OwnerId == OwnerId).Select(s => s.Pokemon).ToList();
        }
    }
}