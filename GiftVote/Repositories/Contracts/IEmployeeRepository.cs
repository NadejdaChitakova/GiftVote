using GiftVote.Data.Models;

namespace GiftVote.Data.Repositories.Contracts;

public interface IEmployeeRepository
{
Task<Employee?> FindByIdAsync(int id, CancellationToken cancellationToken = default);
Task<Employee?> GetEmployeeByCredentials(string username, string password, CancellationToken cancellationToken = default );
}