using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace StyleDemocracy
{
    public static class JsonHelpers
    {
        private static JsonSerializerOptions DefaultOptions => new JsonSerializerOptions 
        {
            AllowTrailingCommas = true,
            Converters = { new JsonStringEnumConverter() },
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };

        public static string ToJson<T>(this T toSerialize) => JsonSerializer.Serialize<T>(toSerialize, DefaultOptions);

        public static T FromJson<T>(this string toDeserialize) => JsonSerializer.Deserialize<T>(toDeserialize, DefaultOptions)
            ?? throw new Exception($"Failed to deserialize into {nameof(T)}");
    }
}
