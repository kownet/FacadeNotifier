/// <summary>
/// API Reference here: https://api.slack.com/docs/messages
/// </summary>
namespace FacadeNotifier.Core.Clients
{
    using Content;
    using Extensions;
    using Newtonsoft.Json;
    using NLog;
    using Payloads.Slack;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using Utils;

    public class SlackClient : ISlackClient
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        private readonly Uri _webhookUrl;
        private readonly HttpClient _httpClient = new HttpClient();

        public SlackClient(Uri webhookUrl)
        {
            _webhookUrl = webhookUrl;
        }

        public async Task SendMessageAsync(IMessage message, IRecipient recipient)
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

            if (recipient.Groups.AnyOrNotNull())
                await SendToSlack(recipient.Groups, payload, "#");

            if (recipient.Users.AnyOrNotNull())
                await SendToSlack(recipient.Users, payload, "@");
        }

        private async Task SendToSlack(string[] recipients, SlackPayload payload, string format)
        {
            foreach (var recipient in recipients)
            {
                payload.Channel = $"{format}{recipient}";

                var serializedPayload = JsonConvert.SerializeObject(payload);
                var response = await _httpClient.PostAsync(_webhookUrl,
                    new StringContent(serializedPayload, Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                    _logger.Info($"SLACK | Message to {recipient} has been sent.");
                else _logger.Info($"SLACK | There were some errors while sending message to {recipient}.");
            }
        }
    }
}