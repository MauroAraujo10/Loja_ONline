using Loja_ONline.Entities;

namespace Loja_ONline.Infra.Repositories.Interface
{
    public interface IVendedorRepository
    {
        Task<List<Vendedores>> GetAll();
    }
}
