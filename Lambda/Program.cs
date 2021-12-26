using System;
using System.Threading.Tasks;
using StyleDemocracy.Infrastructure;

namespace StyleDemocracy.Lambda
{
    public class Program
    {
        private static int RandomizedAmount = 2;
        private static RuleSetId Example_RuleSetId = new RuleSetId("RuleSetId123");
        private static UserId Example_UserId = new UserId("UserId123");
        private static IRepository Repository = new FileRepository(Example_RuleSetId);
        private static PollBooth PollBooth = new PollBooth(Repository, Example_UserId);

        static async Task Main(string[] _)
        {
            var rules = await Repository.LoadRules();

            var randomSubset = rules.RandomizeSubset(RandomizedAmount);

            foreach (var rule in randomSubset)
            {
                Console.Clear();
                Console.WriteLine(rule.ToJson());
                await PollBooth.Poll(rule, Decision("Do you want this rule to be active?"));
            }
        }

        private static bool Decision(string question)
        {
            Console.Write(question + " (y/n) ");
            return Console.ReadKey().KeyChar == 'y';
        }
    }
}
