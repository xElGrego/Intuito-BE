using intuito.application.models.DTOs;
using intuito.domain.DTOs;

namespace intuito.application.interfaces.services
{
    public interface IMovieRepository
    {
        Task<Response> AgregarMovie(MovieDto movie);
        Task<Response> EditarMovie(MovieDto movie);
        Task<Response> EliminarMovie(int idMovie);
    }
}
