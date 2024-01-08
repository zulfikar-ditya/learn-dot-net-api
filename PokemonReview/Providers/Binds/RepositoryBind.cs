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
        }
    }
}