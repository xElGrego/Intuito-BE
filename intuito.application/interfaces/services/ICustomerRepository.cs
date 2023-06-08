using intuito.application.models.DTOs;
using intuito.domain.DTOs;
  

namespace intuito.application.interfaces.services
{
    public interface ICustomerRepository
    {
        Task<Response> AgregarCustomer(CustomerDto customer);
    }
}
