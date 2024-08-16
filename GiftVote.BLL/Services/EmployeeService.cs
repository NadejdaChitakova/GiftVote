using AutoMapper;
using GiftVote.BLL.Contracts;
using GiftVote.BLL.Models.Abstractions;
using GiftVote.BLL.Models.Response;
using GiftVote.Data.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace GiftVote.BLL.Services
{
    internal class EmployeeService(
        IEmployeeRepository employeeRepository,
        IMapper mapper) : IEmployeeService
    {
        public async Task<int?> GetEmployeeByUsername(string username, CancellationToken cancellationToken)
        {
            return await employeeRepository.FindByUsername(username, cancellationToken);
        }

        public async Task<Result<List<EmployeesResponse>>> GetAllEmployees(int loggedUserId, CancellationToken cancellationToken)
        {
            var query = employeeRepository.GetAll(loggedUserId);

            var result = mapper.ProjectTo<EmployeesResponse>(query);

            return await result.ToListAsync(cancellationToken);
        }
    }
}
