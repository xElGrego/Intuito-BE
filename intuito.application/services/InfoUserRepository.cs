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
    public class InfoUserRepository : IUserRepository
    {
        private readonly IUserRestRepository _userRestRepository;

        public InfoUserRepository(IUserRestRepository userRestRepository)
        {
            _userRestRepository = userRestRepository;
        }

        public async Task<Response> AgregarUser(UserDto user)
        {
            return await _userRestRepository.AgregarUser(user);
        }

        public async Task<UserDto> ObtenerUser(string key)
        {
            return await _userRestRepository.ObtenerUser(key);
        }
    }
}
