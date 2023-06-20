using APITemplate.Application.Dto;
using APITemplate.Application.Interface;
using APITemplate.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APITemplate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class TemplatesController : ControllerBase
    {
        private readonly ITemplateSave _templateRegistry;

        public TemplatesController(ITemplateSave templateRegistry)
        {
            _templateRegistry = templateRegistry;
        }

        /// <summary>
        /// Guarda un template
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("/api/template")]
        public async Task<ActionResult<ResponseBase>> Save([FromBody] TemplateSaveRequestDto request)
        {
            try
            {
                ResponseBase response = await _templateRegistry.Save(request);

                if (response.Code == 200)
                {
                    return Ok(response);
                }
                else
                {
                    return StatusCode(response.Code, new ResponseBase
                    {
                        Code = response.Code,
                        Message = response.Message
                    });
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseBase
                {
                    Code = 500,
                    Message = "Se ha producido un error en la peticion"
                });
            }
        }
    }
}
