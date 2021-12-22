namespace StyleDemocracy
{
    public enum Category
    {
        None = 0,
        Documentation = 1,
        Layout = 2
    }
    public class Rule
    {
        public string TypeName { get; }
        public string CheckId { get; }
        public Category Category { get; }
        
        public Rule(string typeName, string checkId, Category category)
        {
            TypeName = typeName;
            CheckId = checkId;
            Category = category;
        }
    }
}
