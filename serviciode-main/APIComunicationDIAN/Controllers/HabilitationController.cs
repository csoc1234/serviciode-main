using APIComunicationDIAN.Application.Dto;
using APIComunicationDIAN.Application.Interface;
using APIComunicationDIAN.Domain.Enum;
using Microsoft.AspNetCore.Mvc;

namespace APIComunicationDIAN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HabilitationController : ControllerBase
    {
        private readonly IDianStatus _status;
        private readonly IDianSend _send;
        private readonly IDianStatusEnable _statusEnable;
        private readonly EnvironmentEnum _environment = EnvironmentEnum.Habilitation;

        public HabilitationController(IDianStatus status, IDianSend send, IDianStatusEnable statusEnable)
        {
            _status = status;
            _send = send;
            _statusEnable = statusEnable;
        }

        [HttpGet("/api/Hab/Consultar/{cufe}")]
        public async Task<ActionResult<DianResponseDto>> GetStatus([FromRoute] string cufe)
        {

            DianResponseDto response = await _status.GetStatus(cufe, _environment);

            return Ok(response);
        }

        [HttpGet("/api/Hab/ConsultarZip/{trackID}")]
        public async Task<ActionResult<DianResponseDto>> GetStatusZip([FromRoute] string trackID)
        {

            DianResponseDto response = await _statusEnable.GetStatusZip(trackID, _environment);

            return Ok(response);
        }

        [HttpPost("/api/Hab/AsyncSet/Enviar")]
        public async Task<ActionResult<DianResponseDto>> PostAsyncSend([FromBody] SendRequestDto request)
        {
            DianResponseDto response = await _send.PostTestSetAsyncSend(request, _environment);

            return Ok(response);
        }

        [HttpPost("/api/Hab/Sync/Enviar")]
        public async Task<ActionResult<DianResponseDto>> PostSyncSend([FromBody] SendRequestDto request)
        {
            DianResponseDto response = await _send.PostSyncSend(request, _environment);

            return Ok(response);
        }
    }
}
