using Grpc.Core;
using intuito.api.greeter.Protos;
using intuito.api.Mapper;
using intuito.api.user.Protos;
using intuito.application.interfaces.services;

namespace intuito.api.Service
{
    public class UserService : User.UserBase
    {
        private readonly ILogger<UserService> _logger;

        private readonly IUserRepository _userRepository;


        public UserService(ILogger<UserService> logger, IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        public async override Task<UserResponse> AddUser(UserRequest request, ServerCallContext context)
        {
            var dtoUser = UserMapper.MapDtoUser(request);
            var response = await _userRepository.AgregarUser(dtoUser);

            return await Task.FromResult(new UserResponse
            {
                Message =  response.res
            });
        }

        public async override Task<UserIdResponse> GetUser(UserIdRequest request, ServerCallContext context)
        {
            var response = await _userRepository.ObtenerUser(request.IdUser);

            return await Task.FromResult(new UserIdResponse
            {
                Name = response.Name,
                LastName = response.LastName,
            });
        }
    }
}
