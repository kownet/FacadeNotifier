namespace FacadeNotifier.Core.Channels
{
    using Content;
    using Responses;
    using System.Threading.Tasks;

    public interface IChannel
    {
        Task<SendResponse> SendAsync(IMessage message, IRecipient recipient);

        string Name { get; }
    }
}