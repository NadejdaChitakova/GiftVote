namespace GiftVote.BLL.Models.Request;

public record StopBallotRequest
{
    public int BallotId { get; set; }
    public int BirthdayGay { get; set; }
};