namespace FacadeNotifier.Core
{
    public interface INotifier
    {
        INotifier WithTitle(string title);
        INotifier WithBody(string body);
        INotifier ToPeople(params string[] toPeople);
        INotifier ToGroups(params string[] toGroups);
        void Send();
    }
}