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

        public CategoryRepositoryInterface Category { get; private set; }

        public CountryRepositoryInterface Country { get; private set; }

        public OwnerRepositoryInterface Owner { get; private set; }

        public ReviewRepositoryInterface Review { get; private set; }

        public ReviewerRepositoryInterface Reviewer { get; private set; }

        public UnitOfWorkRepository(DataContext db)
        {
            _db = db;

            Pokemon = new PokemonRepository(_db);
            Category = new CategoryRepository(_db);
            Country = new CountryRepository(_db);
            Owner = new OwnerRepository(_db);
            Review = new ReviewRepository(_db);
            Reviewer = new ReviewerRepository(_db);
        }
    }
}