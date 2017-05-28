namespace FacadeNotifier.Core.Clients
{
    using Content;
    using System.Threading.Tasks;

    public interface IClient
    {
        /// <summary>
        /// Sends notification using particular client synchronously.
        /// </summary>
        /// <param name="message">Message <see cref="IMessage"/> object.</param>
        /// <param name="recipient">Recipient <see cref="IRecipient"/> object.</param>
        void SendNotification(IMessage message, IRecipient recipient);

        /// <summary>
        /// Sends notification using particular client asynchronously.
        /// </summary>
        /// <param name="message">Message <see cref="IMessage"/> object.</param>
        /// <param name="recipient">Recipient <see cref="IRecipient"/> object.</param>
        /// <returns></returns>
        Task SendNotificationAsync(IMessage message, IRecipient recipient);
    }
}