using System.Collections.Generic;


namespace StyleDemocracy
{
    public class VoteItem
    {
        public RuleSetId RuleSetId { get; }
        public Rule Rule { get; }
        public Dictionary<UserId, bool> Votes { get; }

        public VoteItem(RuleSetId ruleSetId, Rule rule)
            : this(ruleSetId, rule, new Dictionary<UserId, bool>())
        {
        }

        public VoteItem(RuleSetId ruleSetId, Rule rule, Dictionary<UserId, bool> votes)
        {
            RuleSetId = ruleSetId;
            Rule = rule;
            Votes = votes;
        }
    }

    public class UserId
    {
        public string Value { get; }
    }
}
