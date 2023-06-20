using APIGenerateUBL.Application.Dto;
using APIGenerateUBL.Application.Interface;
using Microsoft.AspNetCore.Mvc;
namespace APIGenerateUBL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class GenerateUBLController : ControllerBase
    {
        private readonly IDocumentUbl _documentCreate;

        public GenerateUBLController(
          IDocumentUbl documentUbl)
        {
            _documentCreate = documentUbl;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request">Datos del documento</param>
        /// <returns></returns>
        /// 
        [HttpPost("/api/GenerateDocumentUbl")]
        public async Task<ActionResult<ResponseDto>> PostDocumentUbl([FromBody] DocumentDtoRequest request)
        {
            try
            {

                ResponseDto response = _documentCreate.Generate(request);

                if (response.Code == 500)
                {
                    return UnprocessableEntity(response);
                }
                if (response.Code == 400)
                {
                    return BadRequest(response);
                }
                else
                {
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex);
            }
        }

    }
}
