using GiftVote.Data.Models;

namespace GiftVote.BLL.Contracts;

public interface IJwtProvider
{
    string Generate(Employee employee);
}