using System.Threading.Tasks;

namespace StyleDemocracy
{
    public class PollBooth
    {
        private IRepository Repository { get; }
        private UserId UserId { get; }

        public PollBooth(IRepository repository, UserId userId)
        {
            Repository = repository;
            UserId = userId;
        }

        public Task Poll(Rule rule, bool decision) 
        {
            var item = new VotedItem(rule.CheckId, UserId, decision);

            return Repository.Save(item);
        }
    }
}
