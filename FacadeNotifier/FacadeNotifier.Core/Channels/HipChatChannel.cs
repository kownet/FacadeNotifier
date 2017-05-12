namespace FacadeNotifier.Core.Channels
{
    using Clients;
    using Content;
    using Extensions;
    using NLog;
    using System.Threading.Tasks;

    public class HipChatChannel : BaseChannel, IChannel
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();
        private readonly IHipChatClient _hipchat;

        public HipChatChannel(IHipChatClient hipchat)
        {
            _hipchat = hipchat;
        }

        public string Name => "HipChat";

        public async Task SendAsync(IMessage message, IRecipient recipient)
        {
            if (recipient.Groups.AnyOrNotNull())
                foreach (var group in recipient.Groups)
                    _logger.Info($"Group message to {group} will be send via {Name}.");

            if (recipient.Users.AnyOrNotNull())
                foreach (var user in recipient.Users)
                    _logger.Info($"Direct message to {user} will be send via {Name}.");

            await _hipchat.SendMessageAsync(message, recipient);
        }
    }
}