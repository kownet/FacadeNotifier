namespace FacadeNotifier.App.Main
{
    using Core;
    using Core.Channels;
    using Core.Content;
    using System.Collections.Generic;

    public class Application : IApplication
    {
        public void Run(IEnumerable<IChannel> channels)
        {
            new Notifier(channels)
                .WithTitle("Message title")
                .WithBody("Message body")
                .ToPeople(new string[] { "tomek@kownet.info", "tk" })
                .ToGroups(new string[] { "Api", "Test_api" })
                .SetMessageType(MessageType.Failed)
                .Send();
        }
    }
}