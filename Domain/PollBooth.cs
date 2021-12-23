namespace StyleDemocracy
{
    public class PollBooth
    {
        private UserId UserId { get; }

        public PollBooth(UserId userId)
        {
            UserId = userId;
        }

        public VotedItem Poll(Rule rule, bool decision) => new VotedItem(rule.CheckId, UserId, decision);
    }
}
