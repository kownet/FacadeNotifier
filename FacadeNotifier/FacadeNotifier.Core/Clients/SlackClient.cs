/// <summary>
/// API Reference here: https://api.slack.com/docs/messages
/// </summary>
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
    using Utils;

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
                WithMarkdown = true,
                Attachments = new List<Attachment>
                {
                    new Attachment
                    {
                        Fallback = PayloadContent.SlackPayloadHeader(message),
                        Pretext = PayloadContent.SlackPayloadHeader(message),
                        Color = $"{message.MessageType.ToSlackColor()}",
                        Fields = new List<Field>
                        {
                            new Field
                            {
                                Title = $"{message.Title}",
                                Value = PayloadContent.SlackPayloadContent(message),
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