namespace FacadeNotifier.Core.Payloads.HipChat
{
    using Newtonsoft.Json;

    public class Description
    {
        [JsonProperty("format")]
        public string Format { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}