using Loja_ONline.Entities;

namespace Loja_ONline.Infra.Repositories.Interface
{
    public interface IProdutosRepository
    {
        Task<List<Produtos>> GetAll();
    }
}
