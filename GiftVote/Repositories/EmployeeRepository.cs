using GiftVote.Data.Context;
using GiftVote.Data.Models;
using GiftVote.Data.Repositories.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GiftVote.Data.Repositories
{
    internal sealed class EmployeeRepository(IdentityDbContext context) : IEmployeeRepository
    {
        public async Task<Employee?> FindByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await context
                       .Set<Employee>()
                       .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<Employee?> GetEmployeeByCredentials(string username, string password,
            CancellationToken cancellationToken)
        {
            return await context
                       .Set<Employee>()
                       .FirstOrDefaultAsync(x => x.UserName == username && x.Password == password, cancellationToken);
        }
    }
}
