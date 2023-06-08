using AutoMapper;
using intuito.application.interfaces.repositories;
using intuito.application.models.DTOs;
using intuito.application.models.exceptions;
using intuito.domain.DTOs;
using intuito.domain.entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace intuito.infrastructure.data.repositories.seat
{
    public class SeatRepository : ISeatRestRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;


        public SeatRepository(IConfiguration configuration, DataContext dataContext, IMapper Mapper)
        {
            _configuration = configuration;
            _dataContext = dataContext;
            _mapper = Mapper;

        }

        public async Task<Response> AgregarSeat(SeatDto seat)
        {
    
            try
            {
                //var request = _mapper.Map<SeatEntity>(seat);


                var request = new SeatEntity
                {
                    Number = seat.Number,
                    RowNumber = seat.RowNumber,
                    RoomId = seat.RoomId,
                };

                _dataContext.Seat.Add(request);

                await _dataContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new IntuitoException(ex.Message);
            }

            var response = new Response
            {
                res = "El asiento fue registrado con éxito"
            };

            return response;
          
        }
    }
}
