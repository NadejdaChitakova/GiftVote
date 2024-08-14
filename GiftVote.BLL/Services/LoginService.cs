using GiftVote.BLL.Contracts;
using GiftVote.BLL.Models;
using GiftVote.BLL.Models.Abstractions;
using GiftVote.BLL.Models.Request;
using GiftVote.Data.Repositories.Contracts;

namespace GiftVote.BLL.Services;

public class LoginService(
    IEmployeeRepository employeeRepository,
    IJwtProvider jwtProvider)
    : ILoginService
{
    public async Task<Result<string>> LoginAsync(LoginRequest request)
    {
        var employee = await employeeRepository.GetEmployeeByCredentials(request.username, request.password);

        if (employee is not null)
        {
            return Result.Failure<string>(EmployeeErrors.InvalidCredentials);
        }

        string token = jwtProvider.Generate(employee);

        return token;
    }
}