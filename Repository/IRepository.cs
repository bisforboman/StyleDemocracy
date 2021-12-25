using System.Collections.Generic;

namespace StyleDemocracy
{
    public interface IRepository
    {
        IReadOnlyList<VotedItem> LoadVotes();
        IReadOnlyList<Rule> LoadRules();
        void Save(VotedItem votedItem);
    }
}
