using intuito.application.models.DTOs;
using intuito.domain.DTOs;

namespace intuito.application.interfaces.repositories
{
    public interface ISeatRestRepository
    {
        Task<Response> AgregarSeat(SeatDto seat);

    }
}
