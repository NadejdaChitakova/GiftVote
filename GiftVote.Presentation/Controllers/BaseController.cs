using GiftVote.BLL.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace GiftVote.Presentation.Controllers
{
    public class BaseController(IEmployeeService employeeService) : ControllerBase
    {
        public string UserName => User.Claims.Where(x => x.Type == "preferred_username").Select(x => x.Value).First();

        public int UserId
        {
            get
            {
                if (string.IsNullOrEmpty(UserName))
                {
                    throw new Exception("UserName is null !");
                }

                var id = employeeService.GetEmployeeByUsername(UserName, CancellationToken.None).Result;

                if (!id.HasValue)
                {
                    throw new Exception("User not found");
                }

                return id.Value;
            }
        }
    }
}
