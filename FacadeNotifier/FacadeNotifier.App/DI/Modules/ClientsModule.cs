namespace FacadeNotifier.App.DI.Modules
{
    using Autofac;
    using Core.Clients;
    using System;

    public class ClientsModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new SlackClient(
                new Uri("")))
                .As<ISlackClient>();

            builder.Register(c => new HipChatClient(
                new Uri("https://api.hipchat.com/v2/"),
                roomToken: "",
                messageToken: ""))
                .As<IHipChatClient>();
        }
    }
}