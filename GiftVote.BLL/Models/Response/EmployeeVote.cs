namespace GiftVote.BLL.Models.Response;

public record EmployeeVote
{
    public string EmployeeFullName  { get; set; }
    public string EmployeeGiftVote {  get; set; }
};