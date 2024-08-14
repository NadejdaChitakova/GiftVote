using GiftVote.BLL.Contracts;
using GiftVote.BLL.Models.Abstractions;
using GiftVote.BLL.Models.Request;
using GiftVote.Data.Repositories.Contracts;

namespace GiftVote.BLL.Services;

public class LoginService(
    IEmployeeRepository employeeRepository)
    :ILoginService
{
    public async Task<Result<bool>> LoginAsync(LoginRequest request)
    {
        var isEmployeeExists = await employeeRepository.CheckUserExistsByCredentialsAsync(request.username, request.password);

        return isEmployeeExists;
    }
}