namespace FacadeNotifier.Core.Channels
{
    using Clients;
    using Messages;
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

        public void Send(IMessage message)
        {
            LogMessage = $"Sending '{message.Title}' via {Name}.";
            _logger.Info(LogMessage);

            Task.Run(async () => { await _hipchat.SendMessageAsync(message.Body); });
        }

        public void SetRecipientsByGroup(params string[] toGroups)
        {
            foreach (var group in toGroups)
            {
                LogMessage = $"Group message to {group} will be send via {Name}.";
                _logger.Info(LogMessage);
            }
        }

        public void SetRecipientsById(params string[] toPeople)
        {
            foreach (var person in toPeople)
            {
                LogMessage = $"Private message to {person} will be send via {Name}.";
                _logger.Info(LogMessage);
            }
        }
    }
}