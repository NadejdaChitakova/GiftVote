using GiftVote.BLL.Models.Abstractions;
using GiftVote.BLL.Models.Request;

namespace GiftVote.BLL.Contracts;

public interface IVoteService
{
    Task<Result> Vote(CreateVoteRequest request, CancellationToken cancellationToken, int loggedUserId);
}