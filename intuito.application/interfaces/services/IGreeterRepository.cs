using intuito.application.models.DTOs;

namespace intuito.application.interfaces.services
{
    public interface IGreeterRepository
    {
        Task<Response> Saludo(string nombre);

    }
}
