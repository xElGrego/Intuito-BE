using intuito.application.interfaces.services;
using intuito.application.models.DTOs;
using intuito.domain.DTOs;
using intuito.domain.enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace intuito.api.Controllers.v1
{
    [Tags("Movie")]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiController]
    public class MovieController : BaseController
    {
        private readonly IMovieRepository _movieRepository;
        public MovieController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(DtoResponse<Response>), 200)]
        [ProducesResponseType(typeof(DtoResponseError), 400)]
        [ProducesResponseType(typeof(DtoResponseError), 500)]
        [Route("/intuito/v1/movie/agregar-movie")]
        public async Task<ActionResult<DtoResponse<Response>>> AgregarMovie([FromBody][Required] MovieDto movie)
        {
             var response = await _movieRepository.AgregarMovie(movie);
            return Ok(new DtoResponse<Response>(response));
        }


        [HttpPut]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(DtoResponse<Response>), 200)]
        [ProducesResponseType(typeof(DtoResponseError), 400)]
        [ProducesResponseType(typeof(DtoResponseError), 500)]
        [Route("/intuito/v1/movie/editar-movie")]
        public async Task<ActionResult<DtoResponse<Response>>> EditarMovie([FromBody][Required] MovieDto movie)
        {
            var response = await _movieRepository.EditarMovie(movie);
            return Ok(new DtoResponse<Response>(response));
        }

        [HttpDelete]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(DtoResponse<Response>), 200)]
        [ProducesResponseType(typeof(DtoResponseError), 400)]
        [ProducesResponseType(typeof(DtoResponseError), 500)]
        [Route("/intuito/v1/movie/eliminar-movie")]
        public async Task<ActionResult<DtoResponse<Response>>> EliminarMovie([FromHeader][Required] int idMovie)
        {
            var response = await _movieRepository.EliminarMovie(idMovie);
            return Ok(new DtoResponse<Response>(response));
        }

    }
}
