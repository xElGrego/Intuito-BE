using AutoMapper;
using intuito.application.interfaces.repositories;
using intuito.application.models.DTOs;
using intuito.application.models.exceptions;
using intuito.domain.DTOs;
using intuito.domain.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace intuito.infrastructure.data.repositories.billboard
{
    public class BillboardRepository : IBillboardRestRepository
    {

        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;

        public BillboardRepository(IConfiguration configuration, DataContext dataContext, IMapper Mapper)
        {
            _configuration = configuration;
            _dataContext = dataContext;
            _mapper = Mapper;

        }

        public async Task<List<BillboardDto>> ConsultarBillboard()
        {
           try
           {
                List<BillboardDto> result = new();

                var request = await _mapper.ProjectTo<BillboardDto>(_dataContext.Billboard, null).Where(x => x.Status == true).ToListAsync();

                if (request.Count > 0)
                {
                    result = request;
                }

                return result;
           }
            catch (Exception ex)
           {
                throw new IntuitoException(ex.Message);
           }
        }

        public async Task<Response> AgregarBillboard(BillboardDto billboard)
        {
            try
            {
                var request = _mapper.Map<BillboardEntity>(billboard);
                _dataContext.Billboard.Add(request);
                await _dataContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new IntuitoException(ex.Message);
            }

            var response = new Response
            {
                res = "El billboard fue agregado con éxito"
            };
            return response;
        }

        public async Task<Response> EditarBilboard(BillboardDto billboard)
        {
            try
            {
                var searchData = await _dataContext.Billboard.Where(x => x.Id == billboard.Id && x.Status == true).FirstOrDefaultAsync();
                if (searchData == null)
                {
                    throw new IntuitoException("El billboard que estás buscando no existe");
                }

                searchData.Date = billboard.Date;
                searchData.StartTime = billboard.StartTime;
                searchData.EndTime = billboard.EndTime;
                searchData.MovieId = billboard.MovieId;
                searchData.RoomId = billboard.RoomId;

                await _dataContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new IntuitoException(ex.Message);

            }
            var response = new Response
            {
                res = "La película fue editada con éxito"
            };

            return response;
        }

        public async Task<Response> EliminarBillboard(int idBillboard)
        {
            try
            {
                var searchData = await _dataContext.Billboard.Where(x => x.Id == idBillboard && x.Status == true).FirstOrDefaultAsync();
                if (searchData == null)
                {
                    throw new IntuitoException("El billboard que estás buscando no existe");
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
                res = "El billboard fue eliminado con éxito"
            };

            return response;
        }
    }
}
