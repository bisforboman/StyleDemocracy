using System.Text.Json;

namespace StyleDemocracy
{
    public static class JsonHelpers
    {
        private static JsonSerializerOptions DefaultOptions => new JsonSerializerOptions 
        {
            AllowTrailingCommas = true
        };

        public static string ToJson<T>(this T toSerialize) => JsonSerializer.Serialize<T>(toSerialize, DefaultOptions);

        public static T FromJson<T>(this string toDeserialize) => JsonSerializer.Deserialize<T>(toDeserialize, DefaultOptions);
    }
}
