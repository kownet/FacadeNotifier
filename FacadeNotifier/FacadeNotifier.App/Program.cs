namespace FacadeNotifier.App
{
    using Autofac;
    using Core.Channels;
    using DI;
    using Main;
    using NLog;
    using System;
    using System.Linq;

    class Program
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IApplication>();

                var channelTypes = scope.GetImplementingTypes<IChannel>();

                var channels = channelTypes.Select(t => scope.Resolve(t) as IChannel);

                channels = channels.Where(ch => ch.Name == "Slack");

                try
                {
                    app.Run(channels);
                }
                catch (Exception ex)
                {
                    _logger.Error(ex.Message);
                }
            }

            Console.ReadLine();
        }
    }
}