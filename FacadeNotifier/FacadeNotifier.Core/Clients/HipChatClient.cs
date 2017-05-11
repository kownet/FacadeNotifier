namespace FacadeNotifier.Core.Clients
{
    using Content;
    using Extensions;
    using Newtonsoft.Json;
    using Payloads.HipChat;
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;

    public class HipChatClient : IHipChatClient
    {
        private readonly Uri _webhookUrl;
        private readonly string _roomToken;
        private readonly string _messageToken;
        private readonly HttpClient _httpClient = new HttpClient();

        public HipChatClient(Uri webhookUrl, string roomToken, string messageToken)
        {
            _webhookUrl = webhookUrl;
            _roomToken = roomToken;
            _messageToken = messageToken;
        }

        public async Task<HttpResponseMessage> SendMessageAsync(IMessage message, IRecipient recipient)
        {
            _httpClient.BaseAddress = _webhookUrl;

            var payload = new HipChatPayload
            {
                Color = "green",
                Message = message.Body,
                Notify = true,
                MessageFormat = "text"
            };
            var serializedPayload = JsonConvert.SerializeObject(payload);

            var responseGroup = await SendToHipChat(recipient.Groups, serializedPayload, _roomToken, "room", "notification");

            var responseUser = await SendToHipChat(recipient.Users, serializedPayload, _messageToken, "user", "message");

            return responseGroup.IsSuccessStatusCode && responseUser.IsSuccessStatusCode
                ? new HttpResponseMessage(HttpStatusCode.OK)
                : new HttpResponseMessage()
                {
                    StatusCode = responseGroup.IsSuccessStatusCode ? responseUser.StatusCode : responseGroup.StatusCode
                };
        }

        private async Task<HttpResponseMessage> SendToHipChat(string[] recipients, string serializedPayload, string token, string container, string alert)
        {
            HttpResponseMessage response = null;

            if (recipients.AnyOrNotNull())
            {
                foreach (var group in recipients)
                {
                    var request = new HttpRequestMessage(HttpMethod.Post, $"{container}/{group}/{alert}");
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    request.Content = new StringContent(serializedPayload, Encoding.UTF8, "application/json");

                    response = await _httpClient.SendAsync(request);
                }
            }

            return response;
        }
    }
}