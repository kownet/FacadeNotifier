namespace FacadeNotifier.Core.Clients
{
    using Newtonsoft.Json;
    using System;
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

        public async Task<HttpResponseMessage> SendMessageAsync(string message, string channel = null, string username = null)
        {
            _httpClient.BaseAddress = _webhookUrl;

            var payload = new
            {
                color = "green",
                message = message,
                notify = true,
                message_format = "text"
            };
            var serializedPayload = JsonConvert.SerializeObject(payload);

            var request = new HttpRequestMessage(HttpMethod.Post, "user/tomek@kownet.info/message");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _messageToken);
            request.Content = new StringContent(serializedPayload, Encoding.UTF8, "application/json");
            var response1 = await _httpClient.SendAsync(request);

            var request1 = new HttpRequestMessage(HttpMethod.Post, "room/Api/notification");
            request1.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _roomToken);
            request1.Content = new StringContent(serializedPayload, Encoding.UTF8, "application/json");
            var response2 = await _httpClient.SendAsync(request1);

            return response1;
        }
    }
}