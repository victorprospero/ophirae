using Autofac;
using EMail.Infrastructure.Repositories;

namespace EMail.Infrastructure
{
    public class EMailInfraModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EMailRepository>().AsImplementedInterfaces();

            base.Load(builder);
        }
    }
}
