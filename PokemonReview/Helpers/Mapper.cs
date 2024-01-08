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
        }
    }
}