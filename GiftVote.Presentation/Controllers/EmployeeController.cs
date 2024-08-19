using GiftVote.BLL.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace GiftVote.Presentation.Controllers
{
    [ApiController]
    [Route("api/Employee")]
    [Authorize]
    [EnableCors]
    public class EmployeeController(
        IEmployeeService employeeService) : BaseController(employeeService)
    {
        [HttpGet(nameof(GetAll))]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await employeeService.GetAllEmployees(UserId, cancellationToken);

            if (result.IsFailure)
            {
                return BadRequest(result);
            }

            return Ok(result.Value);
        }
    }
}
