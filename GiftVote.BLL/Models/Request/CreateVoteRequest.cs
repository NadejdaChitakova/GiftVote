namespace GiftVote.BLL.Models.Request;

public record CreateVoteRequest
{
    public int VoterId { get; set; }
    public int GiftId { get; set; }
    public int BallotId { get; set; }
};