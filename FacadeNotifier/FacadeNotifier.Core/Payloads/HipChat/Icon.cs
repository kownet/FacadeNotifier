namespace FacadeNotifier.Core.Payloads.HipChat
{
    using Newtonsoft.Json;

    public class Icon
    {
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}