using GiftVote.BLL.Models.Abstractions;

namespace GiftVote.BLL.Models
{
    public static class EmployeeErrors
    {
        public static Error NotFound = new(
                                           "Employee.Found",
                                           "The employee with the specified identifier was not found");

        public static Error InvalidCredentials = new(
                                                     "Employee.InvalidCredentials",
                                                     "The provided credentials were invalid");

        public static Error BallotForHimself = new(
                                             "Employee.Ballot",
                                             "The employee cannot initiate ballot for himself");

        public static Error BallotAlreadyExistForUser = new(
                                                            "Employee.Ballot",
                                                            "The ballot already exist for this user");

        public static Error VoteForHimself = new(
                                                   "Employee.Vote",
                                                   "The employee cannot vote for himself");

        public static Error AlteadyVote = new(
                                                 "Employee.Vote",
                                                 "The employee is already vote");

    }
}
