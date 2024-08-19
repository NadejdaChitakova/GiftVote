using GiftVote.Data.Models;

namespace GiftVote.Data.Repositories.Contracts;

public interface IVoteRepository
{
    Task<bool> CheckForExistingVote(int voterId, int ballotId);
    Task CreateVote(Vote vote, CancellationToken cancellationToken);
    string? GetWinningGift(int ballotId);
}