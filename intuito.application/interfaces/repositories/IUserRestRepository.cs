using intuito.application.models.DTOs;
using intuito.domain.DTOs;

namespace intuito.application.interfaces.repositories
{
    public interface IUserRestRepository
    {
        Task<Response> AgregarUser(UserDto user);
        Task<UserDto> ObtenerUser(string key);

    }
}
