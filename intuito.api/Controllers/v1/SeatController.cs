using intuito.application.interfaces.repositories;
using intuito.application.interfaces.services;
using intuito.application.models.DTOs;
using intuito.domain.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace intuito.api.Controllers.v1
{
    [Tags("Seat")]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiController]
    public class SeatController : ControllerBase
    {

        private readonly ISeatRestRepository _seatRestRepository;
        public SeatController(ISeatRestRepository seatRestRepository)
        {
            _seatRestRepository = seatRestRepository;
        }

        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(DtoResponse<Response>), 200)]
        [ProducesResponseType(typeof(DtoResponseError), 400)]
        [ProducesResponseType(typeof(DtoResponseError), 500)]
        [Route("/intuito/v1/seat/agregar-asiento")]
        public async Task<ActionResult<DtoResponse<Response>>> AgregarSeat([FromBody][Required] SeatDto seat)
        {
            var response = await _seatRestRepository.AgregarSeat(seat);
            return Ok(new DtoResponse<Response>(response));
        }
    }
}
