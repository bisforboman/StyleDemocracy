namespace StyleDemocracy
{
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
