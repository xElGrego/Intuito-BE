using AutoMapper;
using intuito.application.interfaces.repositories;
using intuito.application.models.DTOs;
using intuito.application.models.exceptions;
using intuito.domain.DTOs;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using System.Text.Json;

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
                var db = _connectionMultiplexer.GetDatabase();
                Console.WriteLine("User" + user);
                await db.StringSetAsync("1",JsonSerializer.Serialize(user));

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

        public async Task<UserDto> ObtenerUser(string key)
        {
            UserDto userDto = new();
            try
            {
                var db = _connectionMultiplexer.GetDatabase();
                var value = await db.StringGetAsync(key);

                if (!value.IsNull)
                {
                    userDto = JsonSerializer.Deserialize<UserDto>(value);
                    Console.WriteLine("");
                }
            }
            catch (Exception ex)
            {
                throw new IntuitoException(ex.Message);
            }
            return userDto;
        }
    }
}
