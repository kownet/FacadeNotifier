# Notifier

When you would like to send notifications to many channels and want to have it done in the most simple way, you should check this repository.

## Supported services

1. [Slack API](https://api.slack.com/docs/messages)
2. [HipChat API](https://developer.atlassian.com/hipchat/guide/sending-messages)

The notifications might be sent to all or one of the above services.

## How to use

Firstly we have to define an `IList<IClient>` with clients that we are going to support.

    var clients = new List<IClient>()
            {
                new HipChatClient(
                    new Uri("https://api.hipchat.com/v2/"),
                    roomToken: "",
                    messageToken: ""),
                new SlackClient(
                    new Uri(""))
            };

Secondly we have to pass this `IList<IClient>` to the notifier.

    new Notifier(clients)
        .WithTitle(message)
        .WithBody("Build")
        .ToPeople(new string[] { "test@kownet.info", "tk" })
        .ToGroups(new string[] { "Api" })
        .SetMessageType(MessageType.Success)
        .WithLink(new ContentLink { Url = "https://kownet.info", Caption = "Kownet" })
        .SendAsync();

That's all. The notification will be send to the provided groups and / or single users.