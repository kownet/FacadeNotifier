namespace FacadeNotifier.Core.Messages
{
    public class Message : IMessage
    {
        public string Title { get; set; }
        public string Body { get; set; }
    }
}