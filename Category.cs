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

    public static class CategoryStrings
    {
        public const string Documentation = "Documentation Rules";
        public const string Layout = "Layout Rules";
    }

    public static class EnumHelper
    {
        public static Category ToDomain(this string str) => str switch
        {
            CategoryStrings.Documentation => Category.Documentation,
            CategoryStrings.Layout        => Category.Layout,
            _                             => Category.None
        };
    }
}
