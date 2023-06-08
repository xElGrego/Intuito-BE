using intuito.application.models.DTOs;
using intuito.domain.DTOs;

namespace intuito.application.interfaces.services
{
    public interface IBilboardRepository
    {
        Task<List<BillboardDto>> ConsultarBillboard();
        Task<Response> AgregarBillboard(BillboardDto billboard);
        Task<Response> EditarBillboard(BillboardDto billboard);
        Task<Response> EliminarBillboard(int idBillboard);
    }
}
