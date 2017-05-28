namespace FacadeNotifier.App.Main
{
    using FacadeNotifier.Core.Clients;
    using System.Collections.Generic;

    public interface IApplication
    {
        void Run(IEnumerable<IClient> clients);
    }
}