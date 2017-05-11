namespace FacadeNotifier.Core.Content
{
    public class Recipient : IRecipient
    {
        public string[] Groups { get; set; }
        public string[] Users { get; set; }
    }
}