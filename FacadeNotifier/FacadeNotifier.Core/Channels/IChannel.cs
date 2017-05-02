namespace FacadeNotifier.Core.Channels
{
    using Messages;

    public interface IChannel
    {
        void SetRecipientsById(params string[] toPeople);
        void SetRecipientsByGroup(params string[] toGroups);
        void Send(IMessage message);
        string Name { get; }
    }
}