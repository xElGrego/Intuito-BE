using AutoMapper;
using intuito.application.interfaces.repositories;
using intuito.application.models.DTOs;
using intuito.application.models.exceptions;
using intuito.domain.DTOs;
using intuito.domain.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace intuito.infrastructure.data.repositories.movie
{
    public class MovieRepository : IMovieRestRepository
    {

        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;

        public MovieRepository(IConfiguration configuration, DataContext dataContext, IMapper Mapper)
        {
            _configuration = configuration;
            _dataContext = dataContext;
            _mapper = Mapper;
        }

        public async Task<Response> AgregarMovie(MovieDto movie)
        {
            try
            {
                var request = _mapper.Map<MovieEntity>(movie);
                _dataContext.Movie.Add(request);
                await _dataContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new IntuitoException(ex.Message);
            }


            var response = new Response
            {
                res = "La película fue ingresada con éxito"
            };

            return response;
        }

        public async Task<Response> EditarMovie(MovieDto movie)
        {

            try
            {
                var searchData = await _dataContext.Movie.Where(X => X.Id == movie.Id).FirstOrDefaultAsync();
                if (searchData == null)
                {
                    throw new IntuitoException("La movie que estás buscando no existe");
                }

                searchData.Name = movie.Name;
                searchData.Genre = movie.Genre;
                searchData.LengthMinutes = movie.LengthMinutes;
                searchData.AllowedAge = movie.AllowedAge;
                searchData.Status = true;

                await _dataContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw new IntuitoException(ex.Message);

            }
            var response = new Response
            {
                res = "La película fue editada con éxito"
            };

            return response;

        }

        public async Task<Response> EliminarMovie(int idMovie)
        {
            try
            {
                var searchData = await _dataContext.Movie.Where(X => X.Id == idMovie).FirstOrDefaultAsync();
                if (searchData == null)
                {
                    throw new IntuitoException("La movie que estás buscando no existe");
                }

                searchData.Status = false;
                await _dataContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new IntuitoException(ex.Message);

            }
            var response = new Response
            {
                res = "La película fue eliminada con éxito"
            };

            return response;

        }
    }
}
