namespace GiftVote.Data.Models
{
    public sealed class Vote
    {
        public int Id { get; init; }
        public int GiftId { get; init; }
public Gifts Gift {  get; init; }
        public int BallotId { get; init; }
        public Ballot Ballot { get; init; }
public int VoterId { get; init; }
public Employee Voter { get; init; }
    }
}
