using Loja_ONline.Entities;

namespace Loja_ONline.Infra.Repositories.Interface
{
    public interface IVendasRepository
    {
        Task<List<Vendas>> GetAll();
        Task<Vendas> GetById(string id);
        Task Create (Vendas venda);
        Task Update(Vendas venda);
        Task Delete(Vendas venda);
    }
}
