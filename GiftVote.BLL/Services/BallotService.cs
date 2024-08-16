using AutoMapper;
using GiftVote.BLL.Contracts;
using GiftVote.BLL.Models;
using GiftVote.BLL.Models.Abstractions;
using GiftVote.BLL.Models.Request;
using GiftVote.BLL.Models.Response;
using GiftVote.Data.Repositories.Contracts;

namespace GiftVote.BLL.Services
{
    public sealed class BallotService(
        IBallotRepository repository,
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
                                                         DateTime.Now,
                                                         id,
                                                         loggedUserId);

            await repository.InsertBallot(ballot, cancellationToken);

            return Result.Success();
        }

        public void Vote(int id, int loggedUserId)
        {
            //if the voter id is different by birthday gay

            // if the voter is already vote for this birthday gay
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

        public void GetBallots(int loggedUserId, CancellationToken cancellationToken)
        {
            var query = repository.GetBallots(loggedUserId, cancellationToken);

            var data = mapper.ProjectTo<GetAllBallots>(query, new Dictionary<string, object> { ["loggedUserId"] = loggedUserId});

            //var totalRecords = data.Count();

            var result = data.ToList();

        }
    }
}
