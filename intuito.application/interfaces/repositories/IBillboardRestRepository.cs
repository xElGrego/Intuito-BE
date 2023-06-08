using intuito.application.models.DTOs;
using intuito.domain.DTOs;

namespace intuito.application.interfaces.repositories
{
    public interface IBillboardRestRepository
    {
        Task<List<BillboardDto>> ConsultarBillboard();
        Task<Response> AgregarBillboard(BillboardDto billboard);
        Task<Response> EditarBilboard(BillboardDto movie);
        Task<Response> EliminarBillboard(int idBillboard);
    }
}
