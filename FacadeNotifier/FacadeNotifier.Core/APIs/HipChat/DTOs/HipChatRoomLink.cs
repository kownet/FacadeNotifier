namespace FacadeNotifier.Core.APIs.HipChat.DTOs
{
    using Newtonsoft.Json;

    public class HipChatRoomLink
    {
        [JsonProperty("self")]
        public string Self { get; set; }
    }
}