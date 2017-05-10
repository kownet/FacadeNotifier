namespace FacadeNotifier.Core.Clients
{
    using System.Net.Http;
    using System.Threading.Tasks;

    public interface IClient
    {
        Task<HttpResponseMessage> SendMessageAsync(string message, string channel = null, string username = null);
    }
}