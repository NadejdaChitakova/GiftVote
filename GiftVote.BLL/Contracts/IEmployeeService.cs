namespace GiftVote.BLL.Contracts
{
    public interface IEmployeeService
    {
        Task<int?> GetEmployeeByUsername(string username, CancellationToken cancellationToken);
    }
}
