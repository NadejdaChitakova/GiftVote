using AutoMapper;
using GiftVote.BLL.Contracts;
using GiftVote.BLL.Models;
using GiftVote.BLL.Models.Abstractions;
using GiftVote.BLL.Models.Request;
using GiftVote.Data.Models;
using GiftVote.Data.Repositories.Contracts;

namespace GiftVote.BLL.Services
{
    internal sealed class VoteService(
        IVoteRepository voteRepository,
        IMapper mapper) : IVoteService
    {
        public async Task<Result> Vote(CreateVoteRequest request, CancellationToken cancellationToken, int loggedUserId)
        {
            var isUserAlreadyVote = await voteRepository.CheckForExistingVote(loggedUserId, request.BallotId);

            if (isUserAlreadyVote)
            {
                return Result.Failure(EmployeeErrors.AlteadyVote);
            }

            var vote = mapper.Map<Vote>(request);
            vote.VoterId = loggedUserId;

            await voteRepository.CreateVote(vote, cancellationToken);

            return Result.Success(vote);
        }
    }
}
