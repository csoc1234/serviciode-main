using APIComunicationDIAN.Application.Dto;
using APIComunicationDIAN.Application.Interface;
using APIComunicationDIAN.Domain.Enum;
using Microsoft.AspNetCore.Mvc;

namespace APIComunicationDIAN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductionController : ControllerBase
    {
        private readonly IDianStatus _status;
        private readonly IDianSend _send;
        private readonly IDianStatusEnable _statusEnable;

        private readonly EnvironmentEnum _environment = EnvironmentEnum.Production;

        public ProductionController(IDianStatus status, IDianSend send, IDianStatusEnable statusEnable)
        {
            _status = status;
            _send = send;
            _statusEnable = statusEnable;
        }

        [HttpGet("/api/Prod/Consultar/{cufe}")]
        public async Task<ActionResult<DianResponseDto>> GetStatus([FromRoute] string cufe)
        {
            DianResponseDto response = await _status.GetStatus(cufe, _environment);

            return Ok(response);
        }
        [HttpGet("/api/Prod/ConsultarZip/{trackID}")]
        public async Task<ActionResult<DianResponseDto>> GetStatusZip([FromRoute] string trackID)
        {

            DianResponseDto response = await _statusEnable.GetStatusZip(trackID, _environment);

            return Ok(response);
        }

        [HttpPost("/api/Prod/AsyncSet/Enviar")]
        public async Task<ActionResult<DianResponseDto>> PostAsynSend([FromBody] SendRequestDto request)
        {
            DianResponseDto response = await _send.PostTestSetAsyncSend(request, _environment);

            return Ok(response);
        }

        [HttpPost("/api/Prod/Sync/Enviar")]
        public async Task<ActionResult<DianResponseDto>> PostSyncSend([FromBody] SendRequestDto request)
        {
            DianResponseDto response = await _send.PostSyncSend(request, _environment);

            return Ok(response);
        }
    }
}
