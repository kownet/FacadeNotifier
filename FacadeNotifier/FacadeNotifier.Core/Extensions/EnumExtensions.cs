namespace FacadeNotifier.Core.Extensions
{
    using Content;

    public static class EnumExtensions
    {
        public static string ToColor(this MessageType messageType)
        {
            switch (messageType)
            {
                case MessageType.Success:
                    return "#00d000";
                case MessageType.Failed:
                    return "#D00000";
                case MessageType.Cancelled:
                    return "#0000d0";
                default:
                    return "#00000c";
            }
        }
    }
}