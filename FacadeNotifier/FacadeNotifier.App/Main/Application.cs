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
                .WithTitle("Project Name")
                .WithBody("Build")
                .ToPeople(new string[] { "tomek@kownet.info", "tk" })
                .ToGroups(new string[] { "Api" })
                .SetMessageType(MessageType.Success)
                .WithLink(new ContentLink { Url = "https://kownet.info", Caption = "Kownet" })
                .Send();
        }
    }
}