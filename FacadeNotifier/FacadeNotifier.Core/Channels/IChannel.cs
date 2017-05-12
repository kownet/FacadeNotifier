namespace FacadeNotifier.Core.Channels
{
    using Content;
    using System.Threading.Tasks;

    public interface IChannel
    {
        Task SendAsync(IMessage message, IRecipient recipient);

        string Name { get; }
    }
}