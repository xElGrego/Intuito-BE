using intuito.application.interfaces.services;
using intuito.application.models.DTOs;
using intuito.domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace intuito.api.Controllers.v1
{
    [Tags("Billboard")]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiController]
    public class BillboardController : ControllerBase
    {
        private readonly IBilboardRepository _bilboardRepository;
        public BillboardController(IBilboardRepository bilboardRepository)
        {
            _bilboardRepository = bilboardRepository;
        }


        [HttpGet]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(DtoResponse<BillboardDto>), 200)]
        [ProducesResponseType(typeof(DtoResponseError), 400)]
        [ProducesResponseType(typeof(DtoResponseError), 500)]
        [Route("/intuito/v1/billboard/consultar-billboard")]
        public async Task<ActionResult<List<DtoResponse<List<BillboardDto>>>>> ConsultarBillboard() 
        {
            var response = await _bilboardRepository.ConsultarBillboard();
            return Ok(new DtoResponse<List<BillboardDto>>(response));
        }


        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(DtoResponse<Response>), 200)]
        [ProducesResponseType(typeof(DtoResponseError), 400)]
        [ProducesResponseType(typeof(DtoResponseError), 500)]
        [Route("/intuito/v1/billboard/agregar-billboard")]
        public async Task<ActionResult<DtoResponse<Response>>> AgregarBillboard([FromBody][Required] BillboardDto billboard)
        {
            var response = await _bilboardRepository.AgregarBillboard(billboard);
            return Ok(new DtoResponse<Response>(response));
        }


        [HttpPut]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(DtoResponse<Response>), 200)]
        [ProducesResponseType(typeof(DtoResponseError), 400)]
        [ProducesResponseType(typeof(DtoResponseError), 500)]
        [Route("/intuito/v1/billboard/editar-billboard")]
        public async Task<ActionResult<DtoResponse<Response>>> EditarBilboard([FromBody][Required] BillboardDto billboard)
        {
            var response = await _bilboardRepository.EditarBillboard(billboard);
            return Ok(new DtoResponse<Response>(response));
        }


        [HttpDelete]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(DtoResponse<Response>), 200)]
        [ProducesResponseType(typeof(DtoResponseError), 400)]
        [ProducesResponseType(typeof(DtoResponseError), 500)]
        [Route("/intuito/v1/billboard/eliminar-billboard")]
        public async Task<ActionResult<DtoResponse<Response>>> EliminarMovie([FromHeader][Required] int idBillboard)
        {
            var response = await _bilboardRepository.EliminarBillboard(idBillboard);
            return Ok(new DtoResponse<Response>(response));
        }

    }
}
