using intuito.application.models.DTOs;
using intuito.domain.DTOs;

namespace intuito.application.interfaces.repositories
{
    public interface IBookingRestRepository
    {
        Task<Response> AgregarBooking(BookingDto booking);
        Task<Response> EditarBooking(BookingDto booking);

    }
}
