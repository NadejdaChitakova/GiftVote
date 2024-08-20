using GiftVote.Data.Context;
using GiftVote.Data.Models;
using GiftVote.Data.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace GiftVote.Data.Repositories
{
    internal sealed class EmployeeRepository(
        IdentityDbContext context) : IEmployeeRepository
    {
        public async Task<Employee?> FindByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await context
                       .Set<Employee>()
                       .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<int?> FindByUsername(string username, CancellationToken cancellationToken)
        {
            return await context
                       .Set<Employee>()
                       .Select(x => x.Id)
                       .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<Employee?> GetEmployeeByCredentials(string username, string password,
            CancellationToken cancellationToken)
        {
            var isPasswordMatch = false;

            var employee = await context.Set<Employee>()
                .Where(x => x.UserName == username)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (employee is not null)
            {
                 isPasswordMatch = BCrypt.Net.BCrypt.Verify(password, employee.Password);
            }

            return isPasswordMatch ? employee : null;
        }

        public IQueryable<Employee> GetAll(int loggedUserId)
        {
            return context.Set<Employee>()
                .Where(x => x.Id != loggedUserId);
        }

        public IQueryable<Employee> GetEmployees(int ballotId)
        {
            return context.Set<Employee>();
        }
    }
}
