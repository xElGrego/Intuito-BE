using intuito.application.interfaces.services;
using intuito.application.models.DTOs;
using intuito.domain.DTOs;
using intuito.infrastructure.data.repositories.billboard;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace intuito.api.Controllers.v1
{
    [Tags("Booking")]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiController]
    public class BookingController : BaseController
    {
        private readonly IBookingRepository _bookingRepository;
        public BookingController(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }


        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(DtoResponse<Response>), 200)]
        [ProducesResponseType(typeof(DtoResponseError), 400)]
        [ProducesResponseType(typeof(DtoResponseError), 500)]
        [Route("/intuito/v1/booking/agregar-booking")]
        public async Task<ActionResult<DtoResponse<Response>>> AgregarBooking([FromBody][Required] BookingDto booking)
        {
            var response = await _bookingRepository.AgregarBooking(booking);
            return Ok(new DtoResponse<Response>(response));
        }

        [HttpPut]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(DtoResponse<Response>), 200)]
        [ProducesResponseType(typeof(DtoResponseError), 400)]
        [ProducesResponseType(typeof(DtoResponseError), 500)]
        [Route("/intuito/v1/billboard/editar-booking")]
        public async Task<ActionResult<DtoResponse<Response>>> EditarBooking([FromBody][Required] BookingDto booking)
        {
            var response = await _bookingRepository.EditarBooking(booking);
            return Ok(new DtoResponse<Response>(response));
        }
    }
}
