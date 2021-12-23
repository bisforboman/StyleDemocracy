using System.Collections.Generic;
using System.Linq;

namespace StyleDemocracy
{
    public class Repository
    {
        private Dictionary<RuleSetId, IReadOnlyList<VotedItem>> Database => 
            "database.json"
                .ReadFile()
                .FromJson<IEnumerable<PersistedVote>>()
                .Select(v => (new RuleSetId(v.RuleSetId ?? string.Empty), ToVotedItem(v)))
                .GroupBy(
                    g => g.Item1, 
                    g => g.Item2,
                    (key, value) => (key, value))
                .Select(kv => KeyValuePair.Create<RuleSetId, IReadOnlyList<VotedItem>>(kv.key, kv.value.ToList()))
                .ToDictionary(
                    x => x.Key, 
                    x => x.Value);

        private static VotedItem ToVotedItem(PersistedVote v) =>
            new VotedItem(
                new CheckId(v.CheckId ?? string.Empty),
                new UserId(v.UserId ?? string.Empty),
                v.Vote
            );

        private RuleSetId RuleSetId { get; }

        public Repository(RuleSetId ruleSetId)
        {
            RuleSetId = ruleSetId;
        }

        public IReadOnlyList<VotedItem> Load()
        {
            if (Database.ContainsKey(RuleSetId))
            {
                return Database[RuleSetId];
            }

            return new List<VotedItem>();
        }

        public void Save(VotedItem votedItem)
        {
            var persistedItem = new PersistedVote
            {
                RuleSetId = RuleSetId,
                CheckId = votedItem.CheckId,
                UserId = votedItem.UserId,
                Vote = votedItem.Vote
            };

            // add persistation
        }
    }
}
