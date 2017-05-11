namespace FacadeNotifier.Core.Clients
{
    using Content;
    using Extensions;
    using Newtonsoft.Json;
    using Payloads.Slack;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;

    public class SlackClient : ISlackClient
    {
        private readonly Uri _webhookUrl;
        private readonly HttpClient _httpClient = new HttpClient();

        public SlackClient(Uri webhookUrl)
        {
            _webhookUrl = webhookUrl;
        }

        public async Task<HttpResponseMessage> SendMessageAsync(IMessage message, IRecipient recipient)
        {
            var payload = new SlackPayload
            {
                Attachments = new List<Attachment>
                {
                    new Attachment
                    {
                        Fallback = $"Result [{message.MessageType}]: <http://url_to_task|Link to resource>",
                        Pretext = $"Result [{message.MessageType}]: <http://url_to_task|Link to resource>",
                        Color = $"{message.MessageType.ToColor()}",
                        Fields = new List<Field>
                        {
                            new Field
                            {
                                Title = $"{message.Title}",
                                Value = $"{message.Body}",
                                Short = false
                            }
                        }
                    }
                }
            };

            var responseGroup = await SendToSlack(recipient.Groups, payload, "#");

            var responseUser = await SendToSlack(recipient.Users, payload, "@");

            return responseGroup.IsSuccessStatusCode && responseUser.IsSuccessStatusCode
                ? new HttpResponseMessage(HttpStatusCode.OK)
                : new HttpResponseMessage()
                {
                    StatusCode = responseGroup.IsSuccessStatusCode ? responseUser.StatusCode : responseGroup.StatusCode
                };
        }

        private async Task<HttpResponseMessage> SendToSlack(string[] recipients, SlackPayload payload, string format)
        {
            HttpResponseMessage response = null;

            if (recipients.AnyOrNotNull())
            {
                foreach (var recipient in recipients)
                {
                    payload.Channel = $"{format}{recipient}";

                    var serializedPayload = JsonConvert.SerializeObject(payload);
                    response = await _httpClient.PostAsync(_webhookUrl,
                        new StringContent(serializedPayload, Encoding.UTF8, "application/json"));
                }
            }

            return response;
        }
    }
}