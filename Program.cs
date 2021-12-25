using System;

namespace StyleDemocracy
{
    public class Program
    {
        private static int RandomizedAmount = 2;
        private static RuleSetId Example_RuleSetId = new RuleSetId("RuleSetId123");
        private static UserId Example_UserId = new UserId("UserId123");
        private static FileRepository Repository = new FileRepository(Example_RuleSetId);
        private static PollBooth PollBooth = new PollBooth(Repository, Example_UserId);
        private static RuleMapper RuleMapper = new RuleMapper(Repository);

        static void Main(string[] _)
        {
            var randomSubset = Repository
                .LoadRules()
                .RandomizeSubset(RandomizedAmount);

            foreach (var rule in randomSubset)
            {
                Console.Clear();
                Console.WriteLine(rule.ToJson());
                PollBooth.Poll(rule, Decision("Do you want this rule to be active?"));
            }
        }

        private static bool Decision(string question)
        {
            Console.Write(question + " (y/n) ");
            return Console.ReadKey().KeyChar == 'y';
        }
    }
}
