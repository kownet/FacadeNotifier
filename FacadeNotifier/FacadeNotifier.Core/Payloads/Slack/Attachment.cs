namespace FacadeNotifier.Core.Payloads.Slack
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class Attachment
    {
        [JsonProperty("fallback")]
        public string Fallback { get; set; }

        [JsonProperty("pretext")]
        public string Pretext { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("fields")]
        public List<Field> Fields { get; set; }
    }
}