using intuito.application.models.DTOs;
using intuito.domain.DTOs;

namespace intuito.application.interfaces.services
{
    public interface IUserRepository
    {
        Task<Response> AgregarUser(UserDto user);
        Task<UserDto> ObtenerUser(string key);

    }
}
