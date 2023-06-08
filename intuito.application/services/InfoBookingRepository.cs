using intuito.application.interfaces.repositories;
using intuito.application.interfaces.services;
using intuito.application.models.DTOs;
using intuito.domain.DTOs;

namespace intuito.application.services
{
    public class InfoBookingRepository : IBookingRepository
    {
        private readonly IBookingRestRepository _bookingRestRepository;

        public InfoBookingRepository(IBookingRestRepository bookingRestRepository)
        {
           _bookingRestRepository = bookingRestRepository;
        }
        public async Task<Response> AgregarBooking(BookingDto booking)
        {
            return await _bookingRestRepository.AgregarBooking(booking);
        }

        public async Task<Response> EditarBooking(BookingDto booking)
        {
            return await _bookingRestRepository.EditarBooking(booking);
        }
    }
}
