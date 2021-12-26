namespace StyleDemocracy.Infrastructure
{
    public static class EnumHelper
    {
        public static Category ToDomain(string str) => str switch
        {
            CategoryStrings.Documentation => Category.Documentation,
            CategoryStrings.Layout        => Category.Layout,
            _                             => Category.None
        };
    }
}
