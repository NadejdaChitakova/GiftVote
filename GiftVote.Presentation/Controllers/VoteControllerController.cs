using GiftVote.BLL.Contracts;
using GiftVote.BLL.Models.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace GiftVote.Presentation.Controllers
{
    [ApiController]
    [Route("api/Vote")]
    [Authorize]
    [EnableCors]
    public class VoteControllerController(
        IEmployeeService employeeService,
        IVoteService voteService) : BaseController(employeeService)
    {
        [HttpPost(nameof(CreateVote))]
        public async Task<IActionResult> CreateVote([FromBody] CreateVoteRequest request,CancellationToken cancellationToken)
        {
            var result = await voteService.Vote(request, cancellationToken, UserId);

            if (result.IsFailure)
            {
                return BadRequest(result);
            }

            return Ok(result.IsSuccess);
        }
    }
}
