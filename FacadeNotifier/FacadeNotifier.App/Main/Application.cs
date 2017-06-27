namespace FacadeNotifier.App.Main
{
    using Core;
    using Core.APIs.HipChat;
    using Core.Content;
    using FacadeNotifier.Core.APIs.Slack;
    using FacadeNotifier.Core.Clients;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class Application : IApplication
    {
        public void Run(IEnumerable<IClient> clients)
        {
            var message = "Test message from Notifier.";

            var peopleToNotify = new List<string>()
            {
                "tomek@kownet.info",
                "tk"
            };

            var hipchatRooms = new HipChatApi().GetRooms().Result;
            var slackRooms = new SlackApi().GetRooms().Result;

            var hipChatRoomsToNotify = hipchatRooms.Select(r => r.Name);

            var slackRoomsToNotify = slackRooms.Select(r => r.Name);

            var allRoomsToNotify = hipChatRoomsToNotify.Concat(slackRoomsToNotify);

            Task.WaitAll(
                new Notifier(clients)
                            .WithTitle(message)
                            .WithBody("Build")
                            .ToPeople(peopleToNotify.ToArray())
                            .ToGroups(allRoomsToNotify.ToArray())
                            .SetMessageType(MessageType.Success)
                            .WithLink(new ContentLink { Url = "https://kownet.info", Caption = "Kownet" })
                            .SendAsync());
        }
    }
}