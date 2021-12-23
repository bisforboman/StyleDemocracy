using System;
using System.Collections.Generic;
using System.Linq;

namespace StyleDemocracy
{
    public class PollBooth
    {
        private RuleSetId RuleSetId { get; }
        private UserId UserId { get; }

        public PollBooth(RuleSetId ruleSetId, UserId userId)
        {
            RuleSetId = ruleSetId;
            UserId = userId;
        }

        public VoteItem Poll(Rule rule, bool decision) => new VoteItem(RuleSetId, rule, UserId, decision);
    }
    public class Program
    {
        private const string StylesFileName = "Styles.json";
        private static int RandomizedAmount = 2;
        private static RuleSetId Example_RuleSetId = new RuleSetId("123");
        private static UserId Example_UserId = new UserId("123");
        private static PollBooth PollBooth = new PollBooth(Example_RuleSetId, Example_UserId);

        static void Main(string[] _)
        {
            var randomSubset = LoadAll()
                .RandomizeSubset(RandomizedAmount);

            var votes = new List<VoteItem>();
            foreach (var rule in randomSubset)
            {
                Console.Clear();
                Console.WriteLine(rule.ToJson());

                var decision = Decision("Do you want this rule to be active?");
                votes.Add(PollBooth.Poll(rule, decision));
            }

            Console.Clear();

            Console.WriteLine(votes.ConvertAll(v => $"{v.Rule.CheckId} {v.Vote}").ToJson());
            
            ClickProceed();
        }

        private static void ClickProceed()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to continue ...");
            Console.ReadKey();
            Console.Clear();
        }

        private static bool Decision(string question)
        {
            Console.Write(question + " (y/n) ");
            return Console.ReadKey().KeyChar == 'y';
        }

        private static IReadOnlyList<Rule> LoadAll() => 
            StylesFileName
            .ReadFile()
            .FromJson<PersistedSetOfRules>()
            .All
            .Select(r => new Rule(
                typeName: r.TypeName,
                checkId: new CheckId(r.CheckId),
                category: r.Category.ToDomain()
            ))
            .ToList();
    }
}
