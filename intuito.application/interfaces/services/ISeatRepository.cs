using intuito.application.models.DTOs;
using intuito.domain.DTOs;

namespace intuito.application.interfaces.services
{
    public interface ISeatRepository
    {
        Task<Response> AgregarSeat(SeatDto seat);
    }
}
