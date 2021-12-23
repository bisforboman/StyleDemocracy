namespace StyleDemocracy
{
    public class VoteItem
    {
        public RuleSetId RuleSetId { get; }
        public Rule Rule { get; }
        public UserId UserId { get; }
        public bool Vote { get; }
        public VoteItem(RuleSetId ruleSetId, Rule rule, UserId userId, bool vote)
        {
            RuleSetId = ruleSetId;
            Rule = rule;
            UserId = userId;
            Vote = vote;
        }
    }
}
