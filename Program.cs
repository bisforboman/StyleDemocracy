using System;
using System.Collections.Generic;
using System.Linq;

namespace StyleDemocracy
{
    public class Program
    {
        private const string StylesFileName = "Styles.json";
        private static int RandomizedAmount = 2;
        private static RuleSetId Example_RuleSetId = new RuleSetId("123");

        static void Main(string[] _)
        {
            Console.Clear();

            var randomSubset = LoadAll()
                .RandomizeSubset(RandomizedAmount)
                .Select(r => new VoteItem(Example_RuleSetId, r));

            Console.WriteLine(randomSubset.ToJson());
            
            Console.WriteLine("Press any key to continue ...");
            Console.ReadKey();   
        }

        private static IReadOnlyList<Rule> LoadAll() => 
            StylesFileName
            .ReadFile()
            .FromJson<PersistedSetOfRules>()
            .All
            .Select(r => new Rule(
                typeName: r.TypeName,
                checkId: r.CheckId,
                category: r.Category.ToDomain()
            ))
            .ToList();
    }
}
