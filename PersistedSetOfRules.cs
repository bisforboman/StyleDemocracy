using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace StyleDemocracy
{
    public class PersistedSetOfRules
    {
        [JsonPropertyName("all")]
        public IEnumerable<PersistedRule> All { get; set; } = Enumerable.Empty<PersistedRule>();
    }

    public class PersistedRule
    {
        [JsonPropertyName("typeName")]
        public string TypeName { get; set; }

        [JsonPropertyName("checkId")]
        public string CheckId { get; set; }
        
        [JsonPropertyName("category")]
        public string Category { get; set; }
    }
}
