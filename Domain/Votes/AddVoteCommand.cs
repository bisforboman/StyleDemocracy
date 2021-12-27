using MediatR;

namespace StyleDemocracy
{
    public class AddVoteCommand : INotification
    {
        public VotedItem Vote { get; }

        public AddVoteCommand(VotedItem vote)
        {
            Vote = vote;
        }
    }
}
