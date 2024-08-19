using GiftVote.BLL.Models.Abstractions;
using GiftVote.BLL.Models.Request;
using GiftVote.BLL.Models.Response;

namespace GiftVote.BLL.Contracts;

public interface IBallotService
{
    Task<Result> StartBallotForUser(int id, int loggedUserId, CancellationToken cancellationToken);
    Task<Result> StopBallotForUser(StopBallotRequest request, int loggedUserId, CancellationToken cancellationToken);
    Task<Result<List<GetAllBallots>>> GetBallots(int loggedUserId, CancellationToken cancellationToken);

    Task<Result<BallotStatisticResponse>> GetBallotResult(int ballotId, CancellationToken cancellationToken);
}