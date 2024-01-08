using Interfaces.Repositories;
using Repositories;

namespace Providers.Binds
{
    public class ServiceBind
    {
        private readonly WebApplicationBuilder _builder;

        public ServiceBind(WebApplicationBuilder builder)
        {
            _builder = builder;
        }

        public void bind()
        {
            // 
        }
    }
}