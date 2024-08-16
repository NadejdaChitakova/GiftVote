using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GiftVote.Presentation.Controllers
{
    public class BallotController : ControllerBase
    {
        [HttpGet(nameof(Index))]
        [Authorize]
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
