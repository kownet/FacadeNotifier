namespace FacadeNotifier.Core.Payloads.HipChat
{
    using Newtonsoft.Json;

    public class Card
    {
        [JsonProperty("style")]
        public string Style { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public Description Description { get; set; }

        [JsonProperty("icon")]
        public Icon Icon { get; set; }

        [JsonProperty("date")]
        public long Date { get; set; }

        [JsonProperty("format")]
        public string Format { get; set; }
    }
}