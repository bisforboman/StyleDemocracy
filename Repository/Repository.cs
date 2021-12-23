using System.Collections.Generic;
using System.Linq;

namespace StyleDemocracy
{
    public class Repository
    {
        private string Database => "database.json".ReadFile();

        public IReadOnlyList<VotedItem> Load(RuleSetId ruleSetId)
        {
            var dict = Database
                .FromJson<Dictionary<string, IEnumerable<PersistedVote>>>();

            if (!dict.ContainsKey(ruleSetId.Value))
            {
                return new List<VotedItem>();
            }

            var rules = dict[ruleSetId.Value];
            
            return rules
                .Select(p => new VotedItem(
                    new CheckId(p.CheckId ?? string.Empty),
                    new UserId(p.UserId ?? string.Empty),
                    p.Vote))
                .ToList();
        }
    }
}
