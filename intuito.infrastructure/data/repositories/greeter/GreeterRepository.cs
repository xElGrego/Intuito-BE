using AutoMapper;
using intuito.application.interfaces.repositories;
using intuito.application.models.DTOs;
using intuito.application.models.exceptions;
using Microsoft.Extensions.Configuration;


namespace intuito.infrastructure.data.repositories.greeter
{
    internal class GreeterRepository : IGreeterRestRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public GreeterRepository(IConfiguration configuration, DataContext dataContext, IMapper Mapper)
        {
            _configuration = configuration;
            _mapper = Mapper;
        }

        public async Task<Response> Saludo(string nombre)
        {
            try
            {
                //lOGICA 

            }
            catch (Exception ex)
            {
                throw new IntuitoException(ex.Message);
            }


            var response = new Response
            {
                res = "Saludos estimado " + nombre
            };

            return response;
        }
    }
}
