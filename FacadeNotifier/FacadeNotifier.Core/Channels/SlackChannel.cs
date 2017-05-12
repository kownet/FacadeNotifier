namespace FacadeNotifier.Core.Channels
{
    using Clients;
    using Content;
    using Extensions;
    using NLog;
    using System.Threading.Tasks;

    public class SlackChannel : BaseChannel, IChannel
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();
        private readonly ISlackClient _slack;

        public SlackChannel(ISlackClient slack)
        {
            _slack = slack;
        }

        public string Name => "Slack";

        public async Task SendAsync(IMessage message, IRecipient recipient)
        {
            if(recipient.Groups.AnyOrNotNull())
                foreach (var group in recipient.Groups)
                    _logger.Info($"Group message to {group} will be send via {Name}.");

            if (recipient.Users.AnyOrNotNull())
                foreach (var user in recipient.Users)
                    _logger.Info($"Direct message to {user} will be send via {Name}.");

            await _slack.SendMessageAsync(message, recipient);
        }
    }
}