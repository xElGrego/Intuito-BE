using intuito.application.models.DTOs;
using intuito.domain.DTOs;

namespace intuito.application.interfaces.services
{
    public interface IBookingRepository
    {
        Task<Response> AgregarBooking(BookingDto booking);
        Task<Response> EditarBooking(BookingDto booking);

    }
}
