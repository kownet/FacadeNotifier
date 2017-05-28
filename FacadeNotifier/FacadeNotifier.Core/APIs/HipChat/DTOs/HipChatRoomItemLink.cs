namespace FacadeNotifier.Core.APIs.HipChat.DTOs
{
    using Newtonsoft.Json;

    public class HipChatRoomItemLink
    {
        [JsonProperty("participants")]
        public string Participants { get; set; }

        [JsonProperty("self")]
        public string Self { get; set; }

        [JsonProperty("webhooks")]
        public string Webhooks { get; set; }
    }
}