using GiftVote.Data.Context;
using GiftVote.Data.Models;
using GiftVote.Data.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace GiftVote.Data.Repositories
{
    internal sealed class VoteRepository(
        IdentityDbContext context) :IVoteRepository
    {
        public Task<bool> CheckForExistingVote(int voterId, int ballotId)
=> context.Set<Vote>()
                .AnyAsync(x => x.VoterId == voterId
                               && x.BallotId == ballotId);

        public async Task CreateVote(Vote vote, CancellationToken cancellationToken) 
        {
            await context.Set<Vote>().AddRangeAsync(vote);
            await context.SaveChangesAsync(cancellationToken);
        }

        public string? GetWinningGift(int ballotId)
=>  context.Set<Vote>()
                .Where(x => x.Id == ballotId)
                .Select(x=> x.Gift.Name)
                .Max();
    }
}
