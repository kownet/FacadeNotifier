namespace FacadeNotifier.App
{
    using Core.Clients;
    using Main;
    using NLog;
    using System;
    using System.Collections.Generic;

    class Program
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            #region Run manually
            var clients = new List<IClient>()
            {
                new HipChatClient(
                    new Uri("https://api.hipchat.com/v2/"),
                    roomToken: "",
                    messageToken: ""),
                new SlackClient(
                    new Uri(""))
            };

            new Application().Run(clients);
            #endregion

            Console.ReadLine();
        }
    }
}