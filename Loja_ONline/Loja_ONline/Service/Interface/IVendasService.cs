using Loja_ONline.Entities.ViewModel.Vendas;

namespace Loja_ONline.Service.Interface
{
    public interface IVendasService
    {
        Task<List<VendasGetDto>> GetAll();
        Task<VendasGetDto> GetById(string id);
        Task Create(VendasPostDto dto);
        Task Update(string id, VendasPostDto dto);
        Task Delete(string id);
    }
}
