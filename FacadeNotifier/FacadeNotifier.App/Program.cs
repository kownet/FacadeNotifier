namespace FacadeNotifier.App
{
    using Autofac;
    using Core.Channels;
    using Core.Clients;
    using DI;
    using Main;
    using NLog;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            #region Run manually
            var channels = new List<IChannel>()
            {
                new HipChatChannel(new HipChatClient(
                    new Uri("https://api.hipchat.com/v2/"),
                    roomToken: "",
                    messageToken: "")),
                new SlackChannel(new SlackClient(
                    new Uri("")))
            };

            new Application().Run(channels);
            #endregion

            #region Run with DI (Autofac)
            //var container = ContainerConfig.Configure();

            //using (var scope = container.BeginLifetimeScope())
            //{
            //    var app = scope.Resolve<IApplication>();

            //    var channelTypes = scope.GetImplementingTypes<IChannel>();

            //    var channels = channelTypes.Select(t => scope.Resolve(t) as IChannel);

            //    try
            //    {
            //        app.Run(channels);
            //    }
            //    catch (Exception ex)
            //    {
            //        _logger.Error(ex.Message);
            //    }
            //}
            #endregion

            Console.ReadLine();
        }
    }
}