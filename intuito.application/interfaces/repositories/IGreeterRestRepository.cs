using intuito.application.models.DTOs;

namespace intuito.application.interfaces.repositories
{
    public interface IGreeterRestRepository
    {
        Task<Response> Saludo(string nombre);
    }
}
