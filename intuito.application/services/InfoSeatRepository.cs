using intuito.application.interfaces.repositories;
using intuito.application.interfaces.services;
using intuito.application.models.DTOs;
using intuito.domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace intuito.application.services
{
    public class InfoSeatRepository : ISeatRepository
    {
        private readonly ISeatRestRepository _seatRestRepository;

        public InfoSeatRepository(ISeatRestRepository seatRestRepository)
        {
            _seatRestRepository = seatRestRepository;
        }

        public async Task<Response> AgregarSeat(SeatDto seat)
        {
            return await _seatRestRepository.AgregarSeat(seat);
        }
    }
}
