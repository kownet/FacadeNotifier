/// <summary>
/// API Reference here: https://developer.atlassian.com/hipchat/guide/sending-messages
/// </summary>
namespace FacadeNotifier.Core.Clients
{
    using Content;
    using Extensions;
    using Newtonsoft.Json;
    using NLog;
    using Payloads.HipChat;
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;
    using Utils;

    public class HipChatClient : IHipChatClient
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        private readonly Uri _webhookUrl;
        private readonly string _roomToken;
        private readonly string _messageToken;

        public HipChatClient(Uri webhookUrl, string roomToken, string messageToken)
        {
            _webhookUrl = webhookUrl;
            _roomToken = roomToken;
            _messageToken = messageToken;
        }

        public void SendNotification(IMessage message, IRecipient recipient)
        {
            throw new NotImplementedException("Use SendNotificationAsync method for sending notifications.");
        }

        public async Task SendNotificationAsync(IMessage message, IRecipient recipient)
        {
            if (recipient.Groups.AnyOrNotNull())
                await SendToHipChatAsync(recipient.Groups, SerializePayload(message), _roomToken, "room", "notification");

            if (recipient.Users.AnyOrNotNull())
                await SendToHipChatAsync(recipient.Users, SerializePayload(message), _messageToken, "user", "message");
        }

        private async Task SendToHipChatAsync(string[] recipients, string serializedPayload, string token, string container, string alert)
        {
            foreach (var recipient in recipients)
            {
                using (var request = new HttpRequestMessage(HttpMethod.Post, $"{container}/{recipient}/{alert}"))
                {
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    request.Content = new StringContent(serializedPayload, Encoding.UTF8, "application/json");

                    using (var httpClient = new HttpClient() { BaseAddress = _webhookUrl })
                    {
                        var response = await httpClient.SendAsync(request);

                        if (response.IsSuccessStatusCode)
                            _logger.Info($"HIPCHAT | Message to {recipient} has been sent.");
                        else _logger.Info($"HIPCHAT | There were some errors while sending message to {recipient}.");
                    }
                }
            }
        }

        private string SerializePayload(IMessage message)
        {
            var payload = new HipChatPayload
            {
                Color = message.MessageType.ToHipChatColor(),
                Message = PayloadContent.HipChatPayloadContent(message),
                Notify = true,
                MessageFormat = "html"
            };

            return JsonConvert.SerializeObject(payload);
        }
    }
}