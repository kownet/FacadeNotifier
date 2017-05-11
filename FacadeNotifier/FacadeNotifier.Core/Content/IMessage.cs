namespace FacadeNotifier.Core.Content
{
    public interface IMessage
    {
        string Title { get; set; }
        string Body { get; set; }
        MessageType MessageType { get; set; }
    }
}