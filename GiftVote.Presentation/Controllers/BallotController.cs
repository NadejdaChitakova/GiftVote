using GiftVote.BLL.Contracts;
using GiftVote.BLL.Models.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace GiftVote.Presentation.Controllers
{
    [ApiController]
    [Route("api/Ballot")]
    [Authorize]
    [EnableCors]
    public class BallotController(
        IEmployeeService employeeService,
        IBallotService ballotService) : BaseController(employeeService)
    {
        [HttpGet(nameof(GetAll))]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await ballotService.GetBallots(UserId, cancellationToken);

            if (result.IsFailure)
            {
                return BadRequest(result);
            }

            return Ok(result.Value);
        }

        [HttpGet(nameof(StartBallot))]
        public async Task<IActionResult> StartBallot(int id, CancellationToken cancellationToken)
        {
            var result = await ballotService.StartBallotForUser(id, UserId, cancellationToken);

            if (result.IsFailure)
            {
                return BadRequest(result);
            }

            return Ok(result.IsSuccess);
        }

        [HttpPost(nameof(StopBallot))]
        public async Task<IActionResult> StopBallot(StopBallotRequest request, CancellationToken cancellationToken)
        {
            var result = await ballotService.StopBallotForUser(request, UserId, cancellationToken);

            if (result.IsFailure)
            {
                return BadRequest(result);
            }

            return Ok(result.IsSuccess);
        }
    }
}
