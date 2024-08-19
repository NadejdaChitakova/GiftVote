using GiftVote.Data.Models;

namespace GiftVote.Data.Repositories.Contracts;

public interface IBallotRepository
{
    Task StopBallot(int ballotId, CancellationToken cancellationToken);

    IQueryable<Ballot> GetBallots(int userId);

    Task<bool> HasExistingBallot(int employeeId, CancellationToken cancellationToken);

    Task InsertBallot(Ballot? ballot, CancellationToken cancellationToken);
}