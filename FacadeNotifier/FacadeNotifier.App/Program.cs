namespace FacadeNotifier.App
{
    using Core.Clients;
    using FacadeNotifier.Core.Utils;
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
                    new Uri(NoticeCredentials.HipChatApiEndpoint),
                    roomToken: NoticeCredentials.HipChatRoomToken,
                    messageToken: NoticeCredentials.HipChatMessageToken),
                new SlackClient(
                    new Uri(NoticeCredentials.SlackHookEndpoint))
            };

            new Application().Run(clients);
            #endregion

            Console.ReadLine();
        }
    }
}