using AutoMapper;
using intuito.application.interfaces.repositories;
using intuito.application.models.DTOs;
using intuito.application.models.exceptions;
using intuito.domain.DTOs;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace intuito.infrastructure.data.repositories.user
{
    internal class UserRepository : IUserRestRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IConnectionMultiplexer _connectionMultiplexer;
 
        public UserRepository(IConfiguration configuration, DataContext dataContext, IMapper Mapper, IConnectionMultiplexer connectionMultiplexer)
        {
            _configuration = configuration;
            _mapper = Mapper;
            _connectionMultiplexer= connectionMultiplexer;
        }

        public async Task<Response> AgregarUser(UserDto user)
        {
            try
            {
                var nameCola = _configuration.GetValue<string>("RedisColaName");

                var db = _connectionMultiplexer.GetDatabase();
                Console.WriteLine("User" + user);
                var serializedUser = JsonConvert.SerializeObject(user);

                await db.ListRightPushAsync(nameCola, serializedUser);
            }
            catch(Exception ex)
            {
                throw new IntuitoException(ex.Message);
            }
            var response = new Response
            {
                res = "Usuario agregado"
            };

            return response;
        }

        public async Task<UserDto> ObtenerUser(string cola)
        {
            UserDto userDto = new();
            try
            {
                var db = _connectionMultiplexer.GetDatabase();

                var queueLength = await db.ListLengthAsync(cola);
                var serializedUsers = await db.ListRangeAsync(cola, 0, queueLength - 1);

                var users = new List<UserDto>();
                foreach (var serializedUser in serializedUsers)
                {
                    var user = JsonConvert.DeserializeObject<UserDto>(serializedUser);
                    users.Add(user);
                }
                Console.WriteLine("Espera");
             }
            catch (Exception ex)
            {
                throw new IntuitoException(ex.Message);
            }
            return userDto;
        }
    }
}
