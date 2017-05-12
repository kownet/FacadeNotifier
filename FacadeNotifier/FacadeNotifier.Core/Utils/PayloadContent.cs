namespace FacadeNotifier.Core.Utils
{
    using Content;

    public static class PayloadContent
    {
        public static string SlackPayloadHeader(IMessage message)
        {
            switch (message.MessageType)
            {
                case MessageType.Success:
                    return $"{message.Body} succeed: {message.Title}";
                case MessageType.Failed:
                    return $"{message.Body} failed: {message.Title}";
                case MessageType.Cancelled:
                    return $"{message.Body} cancelled: {message.Title}";
                default:
                    return message.Body;
            }
        }

        public static string SlackPayloadContent(IMessage message)
        {
            if (message.Link != null)
            {
                switch (message.MessageType)
                {
                    case MessageType.Success:
                        return $"Distribution: <{message.Link.Url}|{message.Link.Caption}>";
                    case MessageType.Failed:
                        return $"Log: <{message.Link.Url}|{message.Link.Caption}>";
                    case MessageType.Cancelled:
                        return $"Cancelled by: <{message.Link.Url}|{message.Link.Caption}>";
                    default:
                        return message.Body;
                }
            }
            else
                return message.Body;
            
        }
    }
}