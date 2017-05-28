namespace FacadeNotifier.Core.APIs.HipChat.DTOs
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class HipChatRoomResponse
    {
        [JsonProperty("items")]
        public List<HipChatRoomItem> Items { get; set; }

        [JsonProperty("links")]
        public HipChatRoomLink Links { get; set; }

        [JsonProperty("maxResults")]
        public int MaxResults { get; set; }

        [JsonProperty("startIndex")]
        public int StartIndex { get; set; }
    }
}