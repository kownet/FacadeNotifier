namespace FacadeNotifier.App.Main
{
    using Core;
    using Core.Channels;
    using System.Collections.Generic;

    public class Application : IApplication
    {
        public void Run(IEnumerable<IChannel> channels)
        {
            new Notifier(channels)
                .WithTitle("Message title")
                .WithBody("Message body")
                .ToPeople(new string[] { "test-user-1", "test-user-3" })
                .ToGroups(new string[] { "test-group-1" })
                .Send();
        }
    }
}