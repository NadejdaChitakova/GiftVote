using System.ComponentModel.DataAnnotations.Schema;

namespace GiftVote.Data.Models;

public sealed class Employee
{
    public Employee(string firstname,
        string lastname,
        string username,
        DateTime birthdayDate)
    {
        FirstName = firstname;
        LastName = lastname;
        UserName = username;
        BirthdayDate = birthdayDate;
    }

    public Employee() { }
    public int Id { get; set; }

    public string FirstName { get; set; } 

    public string LastName { get; set; }

    [NotMapped]
    public string FullName => FirstName + " " + LastName;

    public string UserName { get; set; }

    public string Password  { get; set; }

    public DateTime BirthdayDate { get; set; }

    public List<Vote> Votes { get; set; }

    public List<Ballot> CreatedBallots { get; set; }

    public List<Ballot> EmployeeBallots { get; set; }
}