using GiftVote.BLL.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace GiftVote.Presentation.Controllers
{
    [ApiController]
    [Route("api/Gift")]
    [Authorize]
    [EnableCors]
    public class GiftController(
        IEmployeeService employeeService,
        IGiftService giftService) : BaseController(employeeService)
    {
        [HttpGet(nameof(GetAll))]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await giftService.GetAll(cancellationToken);

            if (result.IsFailure)
            {
                return BadRequest(result);
            }

            return Ok(result.Value);
        }
    }
}
