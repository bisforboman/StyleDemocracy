using System.Collections.Generic;
using System.Linq;

namespace StyleDemocracy
{
    public class VoteItem 
    {
        public RuleSetId RuleSetId { get; }
        public Rule Rule { get; }
        public Dictionary<UserId, bool> Votes { get; }
    }

    public class UserId
    {
        public string Value { get; }
    }
}
