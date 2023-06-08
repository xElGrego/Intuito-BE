using intuito.application.interfaces.repositories;
using intuito.application.interfaces.services;
using intuito.application.models.DTOs;
using intuito.domain.DTOs;
namespace intuito.application.services
{
    public class InfoRoomRepository : IRoomRepository
    {
        private readonly IRoomRestRepository _roomRestRepository;

        public InfoRoomRepository(IRoomRestRepository roomRestRepository)
        {
            _roomRestRepository = roomRestRepository;
        }

        public async Task<Response> AgregarRoom(RoomDto room)
        {
            return await _roomRestRepository.AgregarRoom(room);
        }

        public async Task<Response> EditarRoom(RoomDto room)
        {
            return await _roomRestRepository.EditarRoom(room);
        }

        public async Task<Response> EliminarRoom(int idRoom)
        {
            return await _roomRestRepository.EliminarRoom(idRoom);
        }
    }
}
