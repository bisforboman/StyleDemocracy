namespace StyleDemocracy
{
    public class VotedItem
    {
        public CheckId CheckId { get; }
        public UserId UserId { get; }
        public bool Vote { get; }
        public VotedItem(CheckId checkId, UserId userId, bool vote)
        {
            CheckId = checkId;
            UserId = userId;
            Vote = vote;
        }        
    }
}
