using System.Text.Json.Serialization;

namespace StyleDemocracy.Infrastructure
{
    public class PersistedVote
    {
        [JsonPropertyName("ruleSetId")]
        public string? RuleSetId { get; set; }

        [JsonPropertyName("userId")]
        public string? UserId { get; set; }

        [JsonPropertyName("checkId")]
        public string? CheckId { get; set; }

        [JsonPropertyName("vote")]
        public bool Vote { get; set; }

        public string ToKey() => $"{RuleSetId}_{UserId}#{CheckId}";
    }
}
