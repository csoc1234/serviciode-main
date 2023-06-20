using APILogs.Application.Dto;
using APILogs.Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace APILogs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly ICreate _create;

        public LogController(ICreate create)
        {
            _create = create;
        }

        [HttpPost("/api/log")]
        public async Task<ActionResult<LogResponseDto>> Post([FromBody] LogRequestDto request)
        {
            LogResponseDto response = await _create.Register(request);

            if (response.Code == 200)
            {
                return Ok(response);
            }
            else
            {
                return StatusCode(response.Code, response);
            }
        }
    }
}
