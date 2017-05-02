namespace FacadeNotifier.Core
{
    using Channels;
    using Messages;
    using NLog;
    using System;
    using System.Collections.Generic;

    public class Notifier : INotifier
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        private readonly IEnumerable<IChannel> _channels;
        private readonly IMessage _message;

        public Notifier(IEnumerable<IChannel> channels)
        {
            _channels = channels;

            _message = new Message();
        }

        public void Send()
        {
            if (string.IsNullOrWhiteSpace(_message.Title) || string.IsNullOrWhiteSpace(_message.Body))
                throw new ArgumentException("Message must have a title and body defined.");

            foreach (var channel in _channels)
                channel.Send(_message);

            var log = $"Following message: 'Title - {_message.Title} Body - {_message.Body}' has been sent.";
            _logger.Info(log);
        }

        public INotifier ToPeople(params string[] toPeople)
        {
            foreach (var channel in _channels)
                channel.SetRecipientsById(toPeople);

            return this;
        }

        public INotifier ToGroups(params string[] toGroups)
        {
            foreach (var channel in _channels)
                channel.SetRecipientsById(toGroups);

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
    }
}