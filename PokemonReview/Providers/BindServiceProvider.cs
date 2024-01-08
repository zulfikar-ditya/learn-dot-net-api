using Providers.Binds;

namespace Providers
{
    public class BindServiceProvider
    {
        private readonly WebApplicationBuilder _builder;

        public BindServiceProvider(WebApplicationBuilder builder)
        {
            _builder = builder;
        }

        public void execute()
        {
            RepositoryBind repositoryBind = new RepositoryBind(_builder);
            repositoryBind.bind();

            ServiceBind serviceBind = new ServiceBind(_builder);
            serviceBind.bind();

            UnitOfWorkBind unitOfWorkBind = new UnitOfWorkBind(_builder);
            unitOfWorkBind.bind();
        }
    }
}