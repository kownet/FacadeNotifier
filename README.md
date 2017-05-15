# FacadeNotifier

When you would like to send notifications to many channels and want to have it done in the most simple way, you should check this repository.

## Supported services

1. [Slack API](https://api.slack.com/docs/messages)
2. [HipChat API](https://developer.atlassian.com/hipchat/guide/sending-messages)

The notifications might be sent to one of the above services.

## How to use

Firstly we have to define an `IList<IChannel>` with channels that we are going to support. Build in channels are Slack and HipChat.

    var channels = new List<IChannel>()
            {
                new HipChatChannel(new HipChatClient(
                    new Uri("https://api.hipchat.com/v2/"),
                    roomToken: "",
                    messageToken: "")),
                new SlackChannel(new SlackClient(
                    new Uri("")))
            };

Secondly we have to pass this `IList<IChannel>` to the notifier.

    new Notifier(channels)
                .WithTitle("Project Name")
                .WithBody("Build")
                .ToPeople(new string[] { "test@kownet.info", "tk" })
                .ToGroups(new string[] { "Api" })
                .SetMessageType(MessageType.Success)
                .WithLink(new ContentLink { Url = "https://kownet.info", Caption = "Kownet" })
                .Send();

That's all. The notification will be send to the provided groups and / or single users.