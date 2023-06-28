using Loja_ONline.Entities;

namespace Loja_ONline.Infra.Repositories.Interface
{
    public interface IProdutosRepository
    {
        Task<List<Produtos>> GetAll();
        Task<Produtos> GetById(string id);
        Task Create (Produtos produtos);
        Task Update(Produtos produtos);
        Task Delete(Produtos produto);
    }
}
