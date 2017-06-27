namespace FacadeNotifier.Core.APIs.Slack.DTOs
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class SlackRoomResponse
    {
        [JsonProperty("ok")]
        public bool IsOk { get; set; }

        [JsonProperty("channels")]
        public List<SlackRoomItem> Channels { get; set; }
    }
}