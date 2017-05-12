namespace FacadeNotifier.Core
{
    using Content;

    public interface INotifier
    {
        INotifier WithTitle(string title);
        INotifier WithBody(string body);
        INotifier ToPeople(params string[] toPeople);
        INotifier ToGroups(params string[] toGroups);
        INotifier SetMessageType(MessageType messageType);
        INotifier WithLink(ContentLink link);
        void Send();
    }
}