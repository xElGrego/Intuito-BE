using Grpc.Core;
using intuito.api.Protos;
using intuito.application.interfaces.services;
using intuito.application.models.DTOs;
using intuito.domain.DTOs;
using intuito.infrastructure.data.repositories.billboard;

namespace intuito.api.Service
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;

        private readonly IGreeterRepository _greeterRepository;
   

        public GreeterService(ILogger<GreeterService> logger, IGreeterRepository greeterRepository)
        {
            _logger = logger;
            _greeterRepository = greeterRepository;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply
            {
                Message = "Hola " + request.Name
            });
        }

        public override Task<HelloReply> SayHelloFrom(HelloRequestFrom request, ServerCallContext context)
        {
  
            return Task.FromResult(new HelloReply { Message = $"Hello Post {request.Name} from xd {request.From}" });
        }

        public override async Task<HelloReply> NuevoMetodo(HelloRequest request, ServerCallContext context)
        {
            var response = await _greeterRepository.Saludo(request.Name);
            return await Task.FromResult(new HelloReply
            {
                Message = "Hola " + response.res
            });
        }


    }
}
