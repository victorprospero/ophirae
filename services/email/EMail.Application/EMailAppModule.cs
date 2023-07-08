using Autofac;
using AutoMapper.Contrib.Autofac.DependencyInjection;
using MediatR.Extensions.Autofac.DependencyInjection;

namespace EMail.Application
{
    public class EMailAppModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterMediatR(GetType().Assembly);
            builder.RegisterAutoMapper(GetType().Assembly);

            base.Load(builder);
        }
    }
}
