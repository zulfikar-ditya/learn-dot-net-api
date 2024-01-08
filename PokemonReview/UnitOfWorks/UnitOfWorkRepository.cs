using Interfaces.Repositories;
using Interfaces.UnitOfWorks;
using PokemonReview.Data;
using Repositories;

namespace UnitOfWorks
{
    public class UnitOfWorkRepository : UnitOfWorkRepositoryInterface
    {
        private DataContext _db;

        public PokemonRepositoryInterface Pokemon { get; private set;}

        public UnitOfWorkRepository(DataContext db)
        {
            _db = db;

            Pokemon = new PokemonRepository(_db);
        }
    }
}