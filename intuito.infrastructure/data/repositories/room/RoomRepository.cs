using AutoMapper;
using intuito.application.interfaces.repositories;
using intuito.application.models.DTOs;
using intuito.application.models.exceptions;
using intuito.domain.DTOs;
using intuito.domain.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace intuito.infrastructure.data.repositories.room
{
    public class RoomRepository : IRoomRestRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;

        public RoomRepository(IConfiguration configuration, DataContext dataContext, IMapper Mapper)
        {
            _configuration = configuration;
            _dataContext = dataContext;
            _mapper = Mapper;
        }
        public async Task<Response> AgregarRoom(RoomDto room)
        {
            try
            {
                var request = _mapper.Map<RoomEntity>(room);
                _dataContext.Room.Add(request);
                await _dataContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new IntuitoException(ex.Message);
            }


            var response = new Response
            {
                res = "La sala fue ingresada con éxito"
            };

            return response;
        }

        public async Task<Response> EditarRoom(RoomDto room)
        {

            try
            {
                var searchData = await _dataContext.Room.Where(X => X.Id == room.Id).FirstOrDefaultAsync();
                if (searchData == null)
                {
                    throw new IntuitoException("La movie que estás buscando no existe");
                }

                searchData.Name = room.Name;
                searchData.Number = room.Number;
                searchData.Status = true;

                await _dataContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new IntuitoException(ex.Message);

            }
            var response = new Response
            {
                res = "La sala fue editada con éxito"
            };

            return response;
        }

        public async Task<Response> EliminarRoom(int idRoom)
        {
            try
            {
                var searchData = await _dataContext.Room.Where(X => X.Id == idRoom).FirstOrDefaultAsync();
                if (searchData == null)
                {
                    throw new IntuitoException("La sala que estás buscando no existe");
                }

                searchData.Status = false;
                await _dataContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new IntuitoException(ex.Message);

            }
            var response = new Response
            {
                res = "La sala fue eliminada con éxito"
            };

            return response;
        }
    }
}
