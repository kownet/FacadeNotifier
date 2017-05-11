namespace FacadeNotifier.Core.Payloads.HipChat
{
    using Newtonsoft.Json;

    public class HipChatPayload
    {
        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("notify")]
        public bool Notify { get; set; }

        [JsonProperty("message_format")]
        public string MessageFormat { get; set; }
    }
}