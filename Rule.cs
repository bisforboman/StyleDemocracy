using System.Text.Json.Serialization;

namespace StyleDemocracy
{
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
