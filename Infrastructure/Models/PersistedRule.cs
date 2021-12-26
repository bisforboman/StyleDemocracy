using System.Text.Json.Serialization;

namespace StyleDemocracy.Infrastructure
{
    public class PersistedRule
    {
        [JsonPropertyName("typeName")]
        public string? TypeName { get; set; }

        [JsonPropertyName("checkId")]
        public string? CheckId { get; set; }
        
        [JsonPropertyName("category")]
        public string? Category { get; set; }
    }
}
