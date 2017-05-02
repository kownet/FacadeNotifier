namespace FacadeNotifier.Core.Messages
{
    public interface IMessage
    {
        string Title { get; set; }
        string Body { get; set; }
    }
}