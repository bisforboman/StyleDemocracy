using System;
using System.Collections.Generic;

namespace StyleDemocracy
{
    public class Program
    {
        private static RuleMapper Rules = new RuleMapper();
        private static int RandomizedAmount = 2;
        private static RuleSetId Example_RuleSetId = new RuleSetId("123");
        private static UserId Example_UserId = new UserId("123");
        private static PollBooth PollBooth = new PollBooth(Example_UserId);

        static void Main(string[] _)
        {
            var randomSubset = Rules
                .Load()
                .RandomizeSubset(RandomizedAmount);

            var votes = new List<VotedItem>();
            foreach (var rule in randomSubset)
            {
                Console.Clear();
                Console.WriteLine(rule.ToJson());

                var decision = Decision("Do you want this rule to be active?");
                votes.Add(PollBooth.Poll(rule, decision));
            }

            Console.Clear();

            // Console.WriteLine(votes.ConvertAll(v => $"{v.Rule.CheckId} {v.Vote}").ToJson());
            
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
    }
}
