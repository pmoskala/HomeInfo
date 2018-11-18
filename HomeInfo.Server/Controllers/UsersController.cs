using HomeInfo.Application.Users.Commands.CreateUser;
using HomeInfo.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HomeInfo.Server.Controllers
{
    [Route("api")]
    //[Authorize]
    public class UsersController : BaseController
    {
        [HttpPost("users")]
        public async Task<IActionResult> PostUsers([FromBody]CreateUserCommand command)
        {
            User a = await Mediator.Send(command);
            return Ok(a);
        }
    }
}