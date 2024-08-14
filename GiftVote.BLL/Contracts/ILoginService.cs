using GiftVote.BLL.Models.Abstractions;
using GiftVote.BLL.Models.Request;

namespace GiftVote.BLL.Contracts;

public interface ILoginService
{
    Task<Result<string>> LoginAsync(LoginRequest request);
}