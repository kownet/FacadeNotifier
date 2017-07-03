namespace FacadeNotifier.Core.APIs.Slack.DTOs
{
    using Newtonsoft.Json;

    public class SlackUserProfile
    {
        [JsonProperty("avatar_hash")]
        public string AvatarHash { get; set; }

        [JsonProperty("current_status")]
        public string CurrentStatus { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("real_name")]
        public string RealName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("skype")]
        public string Skype { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("image_24")]
        public string Image24 { get; set; }

        [JsonProperty("image_32")]
        public string Image32 { get; set; }

        [JsonProperty("image_48")]
        public string Image48 { get; set; }

        [JsonProperty("image_72")]
        public string Image72 { get; set; }

        [JsonProperty("image_192")]
        public string Image192 { get; set; }
    }
}