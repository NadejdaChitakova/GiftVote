using GiftVote.Data.Context;
using GiftVote.Data.Models;
using GiftVote.Data.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace GiftVote.Data.Repositories
{
    internal class BallotRepository(
        IdentityDbContext context) : IBallotRepository
    {
        public async Task StopBallot(int ballotId, CancellationToken cancellationToken)
        {
            var ballot = await context.Set<Ballot>()
                .FindAsync(ballotId, cancellationToken);

            if (ballot is not null)
            {
                ballot.EndTime = DateTime.Now;

                var isSuccess = await context.SaveChangesAsync(cancellationToken);
            }

        }

        public IQueryable<Ballot> GetBallots(int userId)
        {
            return context.Set<Ballot>()
                .Where(x => x.GiftReceiverId != userId);
        }

        public async Task<bool> HasExistingBallot(int employeeId, CancellationToken cancellationToken)
        {
            var currentYear = DateTime.Now.Year;

            return await context.Set<Ballot>()
                .AnyAsync(x => x.GiftReceiverId == employeeId
                            && x.StartTime.Year == currentYear, cancellationToken);
        }

        public async Task InsertBallot(Ballot? ballot, CancellationToken cancellationToken)
        {
            if (ballot != null)
            {
                await context.Set<Ballot>()
                    .AddAsync(ballot, cancellationToken);

                await context.SaveChangesAsync(cancellationToken);
            }

        }
    }
}
