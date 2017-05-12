namespace FacadeNotifier.Core.Clients
{
    using Content;
    using System.Threading.Tasks;

    public interface IClient
    {
        Task SendMessageAsync(IMessage message, IRecipient recipient);
    }
}