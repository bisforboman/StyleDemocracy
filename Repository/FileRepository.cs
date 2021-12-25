using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace StyleDemocracy
{
    public class FileRepository : IRepository
    {
        private Dictionary<RuleSetId, IReadOnlyList<VotedItem>> Database =>
            Path.Combine(FilePathAffix, "database.json")
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

        private IReadOnlyList<Rule> AllAvailableRules =>
            Path.Combine(FilePathAffix, "styles.json")
            .ReadFile()
            .FromJson<IEnumerable<PersistedRule>>()
            .Select(r => new Rule(
                typeName: r.TypeName ?? string.Empty,
                checkId: new CheckId(r.CheckId ?? string.Empty),
                category: EnumHelper.ToDomain(r.Category ?? string.Empty)
            ))
            .ToList();

        private static VotedItem ToVotedItem(PersistedVote v) =>
            new VotedItem(
                new CheckId(v.CheckId ?? string.Empty),
                new UserId(v.UserId ?? string.Empty),
                v.Vote
            );

        private RuleSetId RuleSetId { get; }
        private const string FilePathAffix = "Repository";

        public FileRepository(RuleSetId ruleSetId)
        {
            RuleSetId = ruleSetId;
        }

        public IReadOnlyList<VotedItem> LoadVotes()
        {
            if (Database.ContainsKey(RuleSetId))
            {
                return Database[RuleSetId];
            }

            return new List<VotedItem>();
        }

        public IReadOnlyList<Rule> LoadRules() => AllAvailableRules;

        public void Save(VotedItem votedItem)
        {
            var persistedItem = new PersistedVote
            {
                RuleSetId = RuleSetId,
                CheckId = votedItem.CheckId,
                UserId = votedItem.UserId,
                Vote = votedItem.Vote
            };

            Path
                .Combine(FilePathAffix, "Database", persistedItem.ToKey() + ".json")
                .WriteFile(persistedItem.ToJson());
        }
    }
}
