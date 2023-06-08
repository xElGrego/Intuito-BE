using AutoMapper;
using intuito.application.interfaces.repositories;
using intuito.application.models.DTOs;
using intuito.application.models.exceptions;
using intuito.domain.DTOs;
using intuito.domain.entities;
using Microsoft.Extensions.Configuration;
namespace intuito.infrastructure.data.repositories
{
    public  class CustomerRepository : ICustomerRestRepository
    {

        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;

        public CustomerRepository(IConfiguration configuration, DataContext dataContext, IMapper Mapper)
        {
            _configuration = configuration;
            _dataContext = dataContext;
            _mapper = Mapper;

        }


        public async Task<Response> AgregarCustomer(CustomerDto customer)
        {
            try
            {
                var request = _mapper.Map<CustomerEntity>(customer);
                _dataContext.Customer.Add(request);
                await _dataContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new IntuitoException(ex.Message);
            }

            var response = new Response
            {
                res = "El usuario fue agregado con éxito"
            };
            return response;
        }
    }
}
