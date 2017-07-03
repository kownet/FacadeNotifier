namespace FacadeNotifier.Core.APIs.Slack.DTOs
{
    using Newtonsoft.Json;

    public class SlackUserItem
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("team_id")]
        public string TeamId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("deleted")]
        public bool Deleted { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("real_name")]
        public string RealName { get; set; }

        [JsonProperty("tz")]
        public string Tz { get; set; }

        [JsonProperty("tz_label")]
        public string TzLabel { get; set; }

        [JsonProperty("tz_offset")]
        public int TzOffset { get; set; }

        [JsonProperty("profile")]
        public SlackUserProfile Profile { get; set; }

        [JsonProperty("is_admin")]
        public bool IsAdmin { get; set; }

        [JsonProperty("is_owner")]
        public bool IsOwner { get; set; }

        [JsonProperty("updated")]
        public int Updated { get; set; }

        [JsonProperty("has_2fa")]
        public bool Has2fa { get; set; }
    }
}