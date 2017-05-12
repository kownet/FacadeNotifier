namespace FacadeNotifier.Core.Payloads.Slack
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class SlackPayload
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("attachments")]
        public List<Attachment> Attachments { get; set; }

        [JsonProperty("mrkdwn")]
        public bool WithMarkdown { get; set; }
    }
}