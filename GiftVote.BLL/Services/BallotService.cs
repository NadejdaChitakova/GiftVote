using AutoMapper;
using GiftVote.BLL.Contracts;
using GiftVote.BLL.Models;
using GiftVote.BLL.Models.Abstractions;
using GiftVote.BLL.Models.Request;
using GiftVote.BLL.Models.Response;
using GiftVote.Data.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace GiftVote.BLL.Services
{
    public sealed class BallotService(
        IBallotRepository repository,
        IVoteRepository voteRepository,
        IMapper mapper) : IBallotService
    {
        public async Task<Result> StartBallotForUser(int id, int loggedUserId, CancellationToken cancellationToken)
        {
            if (loggedUserId == id)
            {
                return Result.Failure(EmployeeErrors.BallotForHimself);
            }

            var hasExistingBallot = await repository.HasExistingBallot(id, cancellationToken);

            if (hasExistingBallot)
            {
                return Result.Failure(EmployeeErrors.BallotAlreadyExistForUser);
            }

            var ballot = Data.Models.Ballot.CreateBallot(
                                                         DateTime.Now, 
                                                         null,
                                                         loggedUserId,
                                                         id);

            await repository.InsertBallot(ballot, cancellationToken);

            return Result.Success();
        }

        public async Task<Result> StopBallotForUser(StopBallotRequest request, int loggedUserId, CancellationToken cancellationToken)
        {
            if (request.BirthdayGay == loggedUserId)
            {
                return Result.Failure(EmployeeErrors.BallotForHimself);
            }

  await repository.StopBallot(request.BallotId, cancellationToken);

  return Result.Success();
        }

        public async Task<Result<List<GetAllBallots>>> GetBallots(int loggedUserId, CancellationToken cancellationToken)
        {
            var query = repository.GetBallots(loggedUserId);

            var data = mapper.ProjectTo<GetAllBallots>(query, new Dictionary<string, object> { ["loggedUserId"] = loggedUserId});

            var result = await data.ToListAsync(cancellationToken);

            return result;
        }

        public async Task<Result<BallotStatisticResponse>> GetBallotResult(int ballotId, CancellationToken cancellationToken)
        {
            var selectedGift = voteRepository.GetWinningGift(ballotId);


        }
    }
}
