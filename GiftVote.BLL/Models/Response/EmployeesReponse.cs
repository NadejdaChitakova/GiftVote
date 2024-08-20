namespace GiftVote.BLL.Models.Response;

public record EmployeesResponse
{
public int Id { get; set; }

public string FullName { get; set; }

public string BirthDay { get; set; }

public bool HasActualBallot { get; set; }
};