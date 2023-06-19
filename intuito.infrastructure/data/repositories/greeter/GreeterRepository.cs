using AutoMapper;
using intuito.application.interfaces.repositories;
using intuito.application.models.DTOs;
using intuito.application.models.exceptions;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

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
                var myData = new
                {
                    nombre = "Gregorio",
                    apellido = "Avila"
                };

                //Tranform it to Json object
                string jsonData = JsonConvert.SerializeObject(myData);

                //Print the Json object
                Console.WriteLine(jsonData);

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
