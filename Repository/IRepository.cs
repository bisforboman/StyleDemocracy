using System.Collections.Generic;
using System.Threading.Tasks;

namespace StyleDemocracy
{
    public interface IRepository
    {
        Task<IReadOnlyList<VotedItem>> LoadVotes();
        Task<IReadOnlyList<Rule>> LoadRules();
        Task Save(VotedItem votedItem);
    }
}
