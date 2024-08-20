namespace GiftVote.BLL.Models.Response;

public record GetAllBallots
{
    public int Id { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public int CreatorId { get; set; }
    public int GiftReceiverId { get; set; }
    public string GiftReceiverName { get; set; }
    public bool? IsCurrentUserCanStopBallot { get; set; }
    public bool? IsUserVote { get; set; }
};