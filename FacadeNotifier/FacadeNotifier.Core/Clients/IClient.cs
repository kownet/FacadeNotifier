namespace FacadeNotifier.Core.Clients
{
    using Content;
    using System.Threading.Tasks;

    public interface IClient
    {
        Task SendNotificationAsync(IMessage message, IRecipient recipient);
    }
}