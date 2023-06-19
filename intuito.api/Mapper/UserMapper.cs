using intuito.api.Service;
using intuito.api.user.Protos;
using intuito.domain.DTOs;

namespace intuito.api.Mapper
{
    public static class UserMapper
    {
        public static UserDto MapDtoUser(UserRequest dtoFactura)
        {
            UserDto user = new UserDto();
            user.Name = dtoFactura.Name;
            user.LastName = dtoFactura.LastName;
            return user;
        }
    }
}
