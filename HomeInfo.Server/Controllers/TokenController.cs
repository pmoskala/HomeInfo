using HomeInfo.Server.Service;
using HomeInfo.Shared.Model;
using Microsoft.AspNetCore.Mvc;

namespace HomeInfo.Server.Controllers
{
    [Route("api")]
    public class TokenController : Controller
    {
        private readonly IJwtTokenService _tokenService;

        public TokenController(IJwtTokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("Token")]
        public IActionResult GenerateToken([FromBody] TokenViewModel vm)
        {
            // todo call the command to validate user and then create token
            var token = _tokenService.BuildToken(vm.Email);
            return Ok(new { token });
        }
    }
}