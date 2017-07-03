namespace FacadeNotifier.Core.APIs.Slack.DTOs
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class SlackUserResponse
    {
        [JsonProperty("ok")]
        public bool IsOk { get; set; }

        [JsonProperty("members")]
        public List<SlackUserItem> Members { get; set; }
    }
}