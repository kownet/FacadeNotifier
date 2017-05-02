namespace FacadeNotifier.App.DI
{
    using Autofac;
    using Modules;
    using Main;

    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Application>().As<IApplication>();

            builder.RegisterModule(new ChannelsModule());

            return builder.Build();
        }
    }
}