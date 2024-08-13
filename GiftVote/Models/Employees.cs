namespace GiftVote.Data.Models;

public sealed class Employee 
{
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string UserName {  get; set; }

    public string Password  { get; set; }

    public List<Vote> Votes { get; set; }

    public List<Ballot> CreatedBallots { get; set; }

    public List<Ballot> EmployeeBallots { get; set; }
}