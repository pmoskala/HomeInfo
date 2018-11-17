using System.Threading.Tasks;
using HomeInfo.Application.Users.Commands.CreateUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HomeInfo.Server.Controllers
{
    [Route("api")]
    [Authorize]
    public class UsersController : BaseController
    {
        [HttpPost("users")]
        public async Task<IActionResult> PostUsers([FromBody]CreateUserCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}