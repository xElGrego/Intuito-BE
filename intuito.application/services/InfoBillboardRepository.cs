using intuito.application.interfaces.repositories;
using intuito.application.interfaces.services;
using intuito.application.models.DTOs;
using intuito.domain.DTOs;

namespace intuito.application.services
{
    public class InfoBillboardRepository : IBilboardRepository
    {
        private readonly IBillboardRestRepository _billboardRestRepository;

        public InfoBillboardRepository(IBillboardRestRepository billboardRestRepository)
        {
            _billboardRestRepository = billboardRestRepository;
        }
        public async Task<Response> AgregarBillboard(BillboardDto billboard)
        {
            return await _billboardRestRepository.AgregarBillboard(billboard);
        }

        public async Task<List<BillboardDto>> ConsultarBillboard()
        {
            return await _billboardRestRepository.ConsultarBillboard();
        }

        public async Task<Response> EditarBillboard(BillboardDto billboard)
        {
            return await _billboardRestRepository.EditarBilboard(billboard);
        }

        public async Task<Response> EliminarBillboard(int idBillboard)
        {
            return await _billboardRestRepository.EliminarBillboard(idBillboard);
        }
    }
}
