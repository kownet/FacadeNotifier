namespace FacadeNotifier.App.Main
{
    using Core.Channels;
    using System.Collections.Generic;

    public interface IApplication
    {
        void Run(IEnumerable<IChannel> channels);
    }
}