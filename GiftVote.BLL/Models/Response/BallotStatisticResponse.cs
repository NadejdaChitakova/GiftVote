namespace GiftVote.BLL.Models.Response;

public record BallotStatisticResponse
{
    public string Gift {  get; set; }
    public List<EmployeeVote> EmployeeVotes { get; set; }
};