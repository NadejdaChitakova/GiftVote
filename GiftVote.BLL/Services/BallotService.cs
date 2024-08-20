using AutoMapper;
using GiftVote.BLL.Contracts;
using GiftVote.BLL.Models;
using GiftVote.BLL.Models.Abstractions;
using GiftVote.BLL.Models.Request;
using GiftVote.BLL.Models.Response;
using GiftVote.Data.Models;
using GiftVote.Data.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace GiftVote.BLL.Services
{
    public sealed class BallotService(
        IBallotRepository repository,
        IVoteRepository voteRepository,
        IEmployeeRepository employeeRepository,
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

            var ballot = new Ballot(
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

            var query = employeeRepository.GetEmployees(ballotId);

            var result =
                await mapper.ProjectTo<EmployeeVote>(query, new Dictionary<string, object>() { ["ballotId"] = ballotId })
                    .ToListAsync(cancellationToken);

            BallotStatisticResponse response = new()
            {
Gift = selectedGift,
EmployeeVotes = result
            };

            return response;
        }
    }
}
