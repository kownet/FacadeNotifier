namespace FacadeNotifier.App.DI.Modules
{
    using Autofac;
    using System.Reflection;

    public class ChannelsModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.Load("FacadeNotifier.Core"))
                    .Where(t => t.Name.EndsWith("Channel"))
                    .Where(t => !t.IsAbstract)
                    .AsImplementedInterfaces()
                    .AsSelf()
                    .InstancePerDependency();
        }
    }
}