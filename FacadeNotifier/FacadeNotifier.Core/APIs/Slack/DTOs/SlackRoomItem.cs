namespace FacadeNotifier.Core.APIs.Slack.DTOs
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class SlackRoomItem
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("is_channel")]
        public bool IsChannel { get; set; }

        [JsonProperty("created")]
        public int Created { get; set; }

        [JsonProperty("creator")]
        public string Creator { get; set; }

        [JsonProperty("is_archived")]
        public bool IsArchived { get; set; }

        [JsonProperty("is_general")]
        public bool IsGeneral { get; set; }

        [JsonProperty("name_normalized")]
        public string NameNormalized { get; set; }

        [JsonProperty("is_shared")]
        public bool IsShared { get; set; }

        [JsonProperty("is_org_shared")]
        public bool IsOrgShared { get; set; }

        [JsonProperty("is_member")]
        public bool IsMember { get; set; }

        [JsonProperty("members")]
        public List<string> Members { get; set; }

        [JsonProperty("topic")]
        public SlackRoomTopic Topic { get; set; }

        [JsonProperty("purpose")]
        public SlackRoomPurpose Purpose { get; set; }

        [JsonProperty("previous_names")]
        public List<object> PreviousNames { get; set; }

        [JsonProperty("num_members")]
        public int NumMembers { get; set; }
    }
}