using intuito.application.interfaces.services;
using intuito.application.models.DTOs;
using intuito.domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;


namespace intuito.api.Controllers.v1
{
    [Tags("Customer")]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiController]
    public class CustomerController : BaseController
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }


        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(DtoResponse<Response>), 200)]
        [ProducesResponseType(typeof(DtoResponseError), 400)]
        [ProducesResponseType(typeof(DtoResponseError), 500)]
        [Route("/intuito/v1/customer/agregar-customer")]
        public async Task<ActionResult<DtoResponse<Response>>> AgregarCustomer([FromBody][Required] CustomerDto customer )
        {
            var response = await _customerRepository.AgregarCustomer(customer);
            return Ok(new DtoResponse<Response>(response));
        }
    }
}
