using GiftVote.BLL.Contracts;
using GiftVote.Data.Repositories.Contracts;

namespace GiftVote.BLL.Services
{
    internal class EmployeeService(
        IEmployeeRepository employeeRepository) : IEmployeeService
    {
        public async Task<int?> GetEmployeeByUsername(string username, CancellationToken cancellationToken)
        {
            return await employeeRepository.FindByUsername(username, cancellationToken);
        }
    }
}
