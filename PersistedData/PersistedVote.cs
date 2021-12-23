namespace StyleDemocracy
{
    public class PersistedVote
    {
        public string RuleSetId { get; set; }
        public string RuleCheckId { get; set; }
        public string UserId { get; set; }
        public bool Vote { get; set; }
    }
}
