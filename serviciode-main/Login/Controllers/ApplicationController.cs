using Login.Application.Dto;
using Login.Application.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Login.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly ILoginUser _loginUser;

        public ApplicationController(ILoginUser loginUser)
        {
            _loginUser = loginUser;
        }

        [HttpPost("/api/application/login")]
        [AllowAnonymous]
        public async Task<ActionResult<TokenJwtDto>> Login([FromBody] LoginRequest request)
        {
            TokenJwtDto result = await _loginUser.Login(request);

            return result != null ? Ok(result) : Unauthorized(null);
        }
    }
}
