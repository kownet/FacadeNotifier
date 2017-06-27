namespace FacadeNotifier.Core.APIs.Slack.DTOs
{
    using Newtonsoft.Json;

    public class SlackRoomTopic
    {
        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("creator")]
        public string Creator { get; set; }

        [JsonProperty("last_set")]
        public int LastSet { get; set; }
    }
}