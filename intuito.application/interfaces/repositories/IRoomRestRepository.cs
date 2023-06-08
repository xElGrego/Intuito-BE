using intuito.application.models.DTOs;
using intuito.domain.DTOs;


namespace intuito.application.interfaces.repositories
{
    public interface IRoomRestRepository
    {
        Task<Response> AgregarRoom(RoomDto room);
        Task<Response> EditarRoom(RoomDto room);
        Task<Response> EliminarRoom(int idRoom);
    }
}
