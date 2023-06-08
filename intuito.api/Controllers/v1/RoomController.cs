using intuito.application.interfaces.services;
using intuito.application.models.DTOs;
using intuito.domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace intuito.api.Controllers.v1
{
    [Tags("Room")]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiController]
    public class RoomController : BaseController
    {
        private readonly IRoomRepository _roomRepository;
        public RoomController(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(DtoResponse<Response>), 200)]
        [ProducesResponseType(typeof(DtoResponseError), 400)]
        [ProducesResponseType(typeof(DtoResponseError), 500)]
        [Route("/intuito/v1/room/agregar-room")]
        public async Task<ActionResult<DtoResponse<Response>>> AgregaRoom([FromBody][Required] RoomDto room)
        {
            var response = await _roomRepository.AgregarRoom(room);
            return Ok(new DtoResponse<Response>(response));
        }


        [HttpPut]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(DtoResponse<Response>), 200)]
        [ProducesResponseType(typeof(DtoResponseError), 400)]
        [ProducesResponseType(typeof(DtoResponseError), 500)]
        [Route("/intuito/v1/room/editar-room")]
        public async Task<ActionResult<DtoResponse<Response>>> EditarRoom([FromBody][Required] RoomDto room)
        {
            var response = await _roomRepository.EditarRoom(room);
            return Ok(new DtoResponse<Response>(response));
        }

        [HttpDelete]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(DtoResponse<Response>), 200)]
        [ProducesResponseType(typeof(DtoResponseError), 400)]
        [ProducesResponseType(typeof(DtoResponseError), 500)]
        [Route("/intuito/v1/room/eliminar-room")]
        public async Task<ActionResult<DtoResponse<Response>>> EliminarRoom([FromHeader][Required] int idRoom)
        {
            var response = await _roomRepository.EliminarRoom(idRoom);
            return Ok(new DtoResponse<Response>(response));
        }
    }
}
