namespace FacadeNotifier.Core.Clients
{
    using Content;
    using System.Net.Http;
    using System.Threading.Tasks;

    public interface IClient
    {
        Task<HttpResponseMessage> SendMessageAsync(IMessage message, IRecipient recipient);
    }
}