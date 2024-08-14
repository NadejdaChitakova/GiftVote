using GiftVote.BLL.Models.Abstractions;

namespace GiftVote.BLL.Models
{
    public static class EmployeeErrors
    {
        public static Error NotFound = new(
                                           "User.Found",
                                           "The user with the specified identifier was not found");

        public static Error InvalidCredentials = new(
                                                     "User.InvalidCredentials",
                                                     "The provided credentials were invalid");
    }
}
