namespace FacadeNotifier.Core.Content
{
    public interface IRecipient
    {
        string[] Groups { get; set; }
        string[] Users { get; set; }
    }
}