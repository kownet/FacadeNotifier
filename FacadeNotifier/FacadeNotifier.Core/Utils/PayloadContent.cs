namespace FacadeNotifier.Core.Utils
{
    using Content;
    using Extensions;

    public static class PayloadContent
    {
        public static string SlackPayloadHeader(IMessage message)
        {
            switch (message.MessageType)
            {
                case MessageType.Success:
                    return $"{message.Body} succeeded: {message.Title}";
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

        public static string HipChatPayloadContent(IMessage message)
        {
            string header = string.Empty;
            string body = string.Empty;

            if (message.Link != null)
            {
                switch (message.MessageType)
                {
                    case MessageType.Success:
                        {
                            header = $"<strong>{message.Body} succeeded: {message.Title}</strong>";
                            body = $"Distribution: <a href='{message.Link.Url}'>{message.Link.Caption}</a>";
                        }; break;
                    case MessageType.Failed:
                        {
                            header = $"<strong>{message.Body} failed: {message.Title}</strong>";
                            body = $"Log: <a href='{message.Link.Url}'>{message.Link.Caption}</a>";
                        }; break;
                    case MessageType.Cancelled:
                        {
                            header = $"<strong>{message.Body} cancelled: {message.Title}</strong>";
                            body = $"Cancelled by: <a href='{message.Link.Url}'>{message.Link.Caption}</a>";
                        }; break;
                    default:
                        body = ""; break;
                }

                return $"<table>" +
                            $"<tr><td><span style='color: {message.MessageType.ToHipChatColor()}'>{header}</span></td></tr>" +
                            $"<tr><td>{body}</td></tr>" +
                       "</table>";
            }
            else
            {
                switch (message.MessageType)
                {
                    case MessageType.Success:
                        {
                            header = $"<strong>{message.Body} succeeded: {message.Title}</strong>";
                        }; break;
                    case MessageType.Failed:
                        {
                            header = $"<strong>{message.Body} failed: {message.Title}</strong>";
                        }; break;
                    case MessageType.Cancelled:
                        {
                            header = $"<strong>{message.Body} cancelled: {message.Title}</strong>";
                        }; break;
                    default:
                        body = ""; break;
                }

                return $"<table>" +
                            $"<tr><td><span style='color: {message.MessageType.ToHipChatColor()}'>{header}</span></td></tr>" +
                       "</table>";
            }
        }
    }
}