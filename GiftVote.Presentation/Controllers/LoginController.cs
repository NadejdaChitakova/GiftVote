using GiftVote.BLL.Contracts;
using GiftVote.BLL.Models.Request;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace GiftVote.Presentation.Controllers
{
    [ApiController]
    [Route("api/Users")]
    [EnableCors]
    public class LoginController(
        ILoginService loginService) : ControllerBase
    {
        [HttpPost(nameof(Login))]
        public async Task<IActionResult> Login([FromBody] LoginRequest request, CancellationToken cancellationToken)
        {
            var token = await loginService.LoginAsync(request, cancellationToken);

            if (string.IsNullOrEmpty(token.Value))
            {
                return Unauthorized();
            }

            return Ok(token);
        }
    }
}
