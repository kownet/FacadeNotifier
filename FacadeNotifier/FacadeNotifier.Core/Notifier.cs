namespace FacadeNotifier.Core
{
    using Channels;
    using Content;
    using NLog;
    using System;
    using System.Collections.Generic;

    public class Notifier : INotifier
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        private readonly IEnumerable<IChannel> _channels;
        private readonly IMessage _message;
        private readonly IRecipient _recipient;

        public Notifier(IEnumerable<IChannel> channels)
        {
            _channels = channels;

            _message = new Message();
            _recipient = new Recipient();
        }

        public void Send()
        {
            if (string.IsNullOrWhiteSpace(_message.Title) || string.IsNullOrWhiteSpace(_message.Body))
                throw new ArgumentException("Message must have a title and body defined.");

            foreach (var channel in _channels)
            {
                var result = channel.SendAsync(_message, _recipient).Result;

                if(result.Succeed)
                    _logger.Info($"Following message: 'Title - {_message.Title} Body - {_message.Body}' has been sent.");
            }
        }

        public INotifier ToPeople(params string[] toPeople)
        {
            _recipient.Users = toPeople;

            return this;
        }

        public INotifier ToGroups(params string[] toGroups)
        {
            _recipient.Groups = toGroups;

            return this;
        }

        public INotifier WithTitle(string title)
        {
            _message.Title = title;

            return this;
        }

        public INotifier WithBody(string body)
        {
            _message.Body = body;

            return this;
        }

        public INotifier SetMessageType(MessageType messageType)
        {
            _message.MessageType = messageType;

            return this;
        }
    }
}