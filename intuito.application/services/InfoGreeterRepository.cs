using intuito.application.interfaces.repositories;
using intuito.application.interfaces.services;
using intuito.application.models.DTOs;


namespace intuito.application.services
{
    public class InfoGreeterRepository : IGreeterRepository
    {
        private readonly IGreeterRestRepository _greeterRestRepository;

        public InfoGreeterRepository(IGreeterRestRepository greeterRestRepository)
        {
            _greeterRestRepository = greeterRestRepository;
        }

        public async Task<Response> Saludo(string nombre)
        {
            return await _greeterRestRepository.Saludo(nombre);
        }
    }
}
