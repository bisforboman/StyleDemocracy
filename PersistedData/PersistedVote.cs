using System.Text.Json.Serialization;

namespace StyleDemocracy
{
    public class PersistedVote
    {
        [JsonPropertyName("checkId")]
        public string? CheckId { get; set; }

        [JsonPropertyName("userId")]
        public string? UserId { get; set; }

        [JsonPropertyName("vote")]
        public bool Vote { get; set; }
    }
}
