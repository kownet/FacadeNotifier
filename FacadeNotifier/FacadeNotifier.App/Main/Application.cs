namespace FacadeNotifier.App.Main
{
    using Core;
    using Core.APIs.HipChat;
    using Core.Content;
    using FacadeNotifier.Core.Clients;
    using System.Collections.Generic;
    using System.Linq;

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

            var rooms = new HipChatApi().GetRooms().Result;

            var roomsToNotify = rooms.Select(r => r.Name);

            new Notifier(clients)
                        .WithTitle(message)
                        .WithBody("Build")
                        .ToPeople(peopleToNotify.ToArray())
                        .ToGroups(roomsToNotify.ToArray())
                        .SetMessageType(MessageType.Success)
                        .Send();
        }
    }
}