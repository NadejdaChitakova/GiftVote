using GiftVote.Data.Models;

namespace GiftVote.Data.Repositories.Contracts;

public interface IEmployeeRepository
{
Task<Employee?> FindByIdAsync(int id, CancellationToken cancellationToken);
Task<int?> FindByUsername(string username, CancellationToken cancellationToken);
Task<Employee?> GetEmployeeByCredentials(string username, string password, CancellationToken cancellationToken);
}