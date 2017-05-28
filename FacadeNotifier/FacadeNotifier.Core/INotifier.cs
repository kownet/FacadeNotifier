namespace FacadeNotifier.Core
{
    using Content;
    using System.Threading.Tasks;

    public interface INotifier
    {
        /// <summary>
        /// The notification title (required).
        /// </summary>
        /// <param name="title">Title / Header</param>
        INotifier WithTitle(string title);

        /// <summary>
        /// The notification body (required).
        /// </summary>
        /// <param name="body">Body / Content</param>
        INotifier WithBody(string body);

        /// <summary>
        /// Set the list of people / ids / emails which will receive a notification (optional).
        /// </summary>
        /// <param name="toPeople">List of people / ids / emails</param>
        INotifier ToPeople(params string[] toPeople);

        /// <summary>
        /// Set the list of groups / rooms / channels which will receive a notification (optional).
        /// </summary>
        /// <param name="toGroups">List of groups / rooms / channels</param>
        INotifier ToGroups(params string[] toGroups);

        /// <summary>
        /// Set the type of notification (required).
        /// </summary>
        /// <param name="messageType">Type <see cref="MessageType"/> object.</param>
        INotifier SetMessageType(MessageType messageType);

        /// <summary>
        /// Set the link which will be a part of the notification (optional).
        /// </summary>
        /// <param name="link">Link <see cref="ContentLink"/> object.</param>
        INotifier WithLink(ContentLink link);

        /// <summary>
        /// Sends notification synchronously.
        /// </summary>
        void Send();

        /// <summary>
        /// Sends notification asynchronously.
        /// </summary>
        /// <returns></returns>
        Task SendAsync();
    }
}