namespace FacadeNotifier.Core.Extensions
{
    using Content;

    public static class EnumExtensions
    {
        public static string ToSlackColor(this MessageType messageType)
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
                    return "#0000d0";
            }
        }

        public static string ToHipChatColor(this MessageType messageType)
        {
            switch (messageType)
            {
                case MessageType.Success:
                    return "green";
                case MessageType.Failed:
                    return "red";
                case MessageType.Cancelled:
                    return "gray";
                default:
                    return "gray";
            }
        }
    }
}