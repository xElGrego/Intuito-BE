using intuito.application.interfaces.repositories;
using intuito.application.interfaces.services;
using intuito.application.models.DTOs;
using intuito.domain.DTOs;
using intuito.domain.entities;

namespace intuito.application.services
{

    public class InfoCustomerRepository : ICustomerRepository
    {
        private readonly ICustomerRestRepository _customerRestRepository;

        public InfoCustomerRepository(ICustomerRestRepository customerRestRepository)
        {
            _customerRestRepository = customerRestRepository;
        }

        public async Task<Response> AgregarCustomer(CustomerDto customer)
        {
            return await _customerRestRepository.AgregarCustomer(customer);
        }
    }
}
