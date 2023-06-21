using Loja_ONline.Entities.ViewModel.Vendedor;

namespace Loja_ONline.Service.Interface
{
    public interface IVendedorService
    {
        public Task<List<VendedorGetDto>> GetAll();
    }
}
