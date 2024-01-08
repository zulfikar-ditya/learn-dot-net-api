using Interfaces.Repositories;
using Interfaces.UnitOfWorks;
using Repositories;
using UnitOfWorks;

namespace Providers.Binds
{
    public class UnitOfWorkBind
    {
        private readonly WebApplicationBuilder _builder;

        public UnitOfWorkBind(WebApplicationBuilder builder)
        {
            _builder = builder;
        }

        public void bind()
        {
            _builder.Services.AddScoped<UnitOfWorkRepositoryInterface, UnitOfWorkRepository>();
        }
    }
}