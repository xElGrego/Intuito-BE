using AutoMapper;
using intuito.application.interfaces.repositories;
using intuito.application.models.DTOs;
using intuito.application.models.exceptions;
using intuito.domain.DTOs;
using intuito.domain.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace intuito.infrastructure.data.repositories.booking
{
    public class BookingRepository : IBookingRestRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;

        public BookingRepository(IConfiguration configuration, DataContext dataContext, IMapper Mapper)
        {
            _configuration = configuration;
            _dataContext = dataContext;
            _mapper = Mapper;

        }
        public async Task<Response> AgregarBooking(BookingDto booking)
        {
            try
            {
                var request = _mapper.Map<BookingEntity>(booking);
                _dataContext.Booking.Add(request);
                await _dataContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new IntuitoException(ex.Message);
            }

            var response = new Response
            {
                res = "El booking fue agregado con éxito"
            };
            return response;
        }

        public async Task<Response> EditarBooking(BookingDto booking)
        {
            try
            {
                var searchData = await _dataContext.Booking.Where(x => x.Id == booking.Id && x.Status == true).FirstOrDefaultAsync();
                if (searchData == null)
                {
                    throw new IntuitoException("El booking que estás buscando no existe");
                }

                searchData.Date = booking.Date;
                searchData.CustomerId = booking.CustomerId;
                searchData.SeatId = booking.SeatId;
                searchData.BillboardId = booking.BillboardId;

                await _dataContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new IntuitoException(ex.Message);

            }
            var response = new Response
            {
                res = "El booking fue editado con éxito"
            };

            return response;
        }


    }
}
