using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeInfo.Application.Users.Commands.CreateUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HomeInfo.Server.Controllers
{
    [Route("api")]
    public class UsersController : BaseController
    {
        [HttpPost("users")]
        public async Task<IActionResult> PostUsers([FromBody]CreateUserCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}