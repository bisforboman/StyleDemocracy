namespace StyleDemocracy
{
    public class PollBooth
    {
        private FileRepository Repository { get; }
        private UserId UserId { get; }

        public PollBooth(FileRepository repository, UserId userId)
        {
            Repository = repository;
            UserId = userId;
        }

        public void Poll(Rule rule, bool decision) 
        {
            var item = new VotedItem(rule.CheckId, UserId, decision);

            Repository.Save(item);
        }
    }
}
