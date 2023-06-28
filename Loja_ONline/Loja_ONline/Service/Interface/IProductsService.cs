using Loja_ONline.Entities.ViewModel.Produtos;

namespace Loja_ONline.Service.Interface
{
    public interface IProductsService
    {
        Task<List<ProdutosGetDto>> GetAll();
        Task<ProdutosGetDto> GetById(string id);
        Task Create(ProdutosPostDto dto);
        Task Update(string id, ProdutosPostDto dto);
        Task Delete(string id);
    }
}
