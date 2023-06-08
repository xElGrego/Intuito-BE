using intuito.application.interfaces.repositories;
using intuito.application.interfaces.services;
using intuito.application.models.DTOs;
using intuito.domain.DTOs;

namespace intuito.application.services
{
    public class InfoMovieRepository : IMovieRepository
    {
        private readonly IMovieRestRepository _movieRestRepository;

        public InfoMovieRepository(IMovieRestRepository customerRestRepository)
        {
            _movieRestRepository = customerRestRepository;
        }

        public async Task<Response> AgregarMovie(MovieDto movie)
        {
            return await _movieRestRepository.AgregarMovie(movie);
        }

        public async Task<Response> EditarMovie(MovieDto movie)
        {
            return await _movieRestRepository.EditarMovie(movie);
        }

        public async Task<Response> EliminarMovie(int idMovie)
        {
            return await _movieRestRepository.EliminarMovie(idMovie);
        }
    }
}
