using Loja_ONline.Entities.ViewModel.Produtos;

namespace Loja_ONline.Service.Interface
{
    public interface IProductsService
    {
        Task<List<ProductsViewModel>> GetAll();
    }
}
