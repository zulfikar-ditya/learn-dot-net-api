using AutoMapper;
using Interfaces.Repositories;
using PokemonReview.Data;
using PokemonReview.Models;

namespace Repositories
{
    public class OwnerRepository : Repository<Owner>, OwnerRepositoryInterface
    {
        private readonly DataContext _dataContext;

        private readonly IMapper _mapper;

        public OwnerRepository(DataContext dataContext, IMapper mapper) : base(dataContext)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }
    }
}