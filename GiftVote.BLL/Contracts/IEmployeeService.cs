using GiftVote.BLL.Models.Abstractions;
using GiftVote.BLL.Models.Response;

namespace GiftVote.BLL.Contracts
{
    public interface IEmployeeService
    {
        Task<int?> GetEmployeeByUsername(string username, CancellationToken cancellationToken);
        Task<Result<List<EmployeesResponse>>> GetAllEmployees(int loggedUserId, CancellationToken cancellationToken);
    }
}
