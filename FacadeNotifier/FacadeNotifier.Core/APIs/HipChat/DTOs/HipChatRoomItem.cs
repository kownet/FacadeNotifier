namespace FacadeNotifier.Core.APIs.HipChat.DTOs
{
    using Newtonsoft.Json;

    public class HipChatRoomItem
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("is_archived")]
        public bool IsArchived { get; set; }

        [JsonProperty("links")]
        public HipChatRoomItemLink Links { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("privacy")]
        public string Privacy { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }
    }
}