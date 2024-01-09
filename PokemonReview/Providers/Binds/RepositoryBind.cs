using Interfaces.Repositories;
using Repositories;

namespace Providers.Binds
{
    public class RepositoryBind
    {
        private readonly WebApplicationBuilder _builder;

        public RepositoryBind(WebApplicationBuilder builder)
        {
            _builder = builder;
        }

        public void bind()
        {
            _builder.Services.AddScoped<PokemonRepositoryInterface, PokemonRepository>();
            _builder.Services.AddScoped<CategoryRepositoryInterface, CategoryRepository>();
            _builder.Services.AddScoped<CountryRepositoryInterface, CountryRepository>();
            _builder.Services.AddScoped<OwnerRepositoryInterface, OwnerRepository>();
            _builder.Services.AddScoped<ReviewRepositoryInterface, ReviewRepository>();
            _builder.Services.AddScoped<ReviewerRepositoryInterface, ReviewerRepository>();
        }
    }
}