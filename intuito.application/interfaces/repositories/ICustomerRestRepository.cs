using intuito.application.models.DTOs;
using intuito.domain.DTOs;
  

namespace intuito.application.interfaces.repositories
{
    public interface ICustomerRestRepository
    {
        Task<Response> AgregarCustomer(CustomerDto customer);
    }
}
