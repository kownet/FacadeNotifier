namespace FacadeNotifier.Core.Content
{
    public class Message : IMessage
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public MessageType MessageType { get; set; }
        public ContentLink Link { get; set; }
    }
}