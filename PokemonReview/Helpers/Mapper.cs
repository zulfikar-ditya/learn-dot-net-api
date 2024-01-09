using AutoMapper;
using Dtos;
using PokemonReview.Models;

namespace Helpers
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Pokemon, PokemonDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<Country, CountryDto>();
            CreateMap<Owner, OwnerDto>();
            CreateMap<Review, ReviewDto>();
            CreateMap<Reviewer, ReviewerDto>();
        }
    }
}