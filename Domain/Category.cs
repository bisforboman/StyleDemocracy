using System.Text.Json.Serialization;

namespace StyleDemocracy
{
    public enum Category
    {
        None = 0,

        [JsonPropertyName(CategoryStrings.Documentation)]
        Documentation = 1,

        [JsonPropertyName(CategoryStrings.Layout)]
        Layout = 2
    }
}
