using GiftVote.BLL.Models.Abstractions;
using GiftVote.BLL.Models.Request;

namespace GiftVote.BLL.Contracts;

public interface IBallotService
{
    Task<Result> StartBallotForUser(int id, int loggedUserId, CancellationToken cancellationToken);
    Task<Result> StopBallotForUser(StopBallotRequest request, int loggedUserId, CancellationToken cancellationToken);
    void GetBallots(int loggedUserId, CancellationToken cancellationToken);
}