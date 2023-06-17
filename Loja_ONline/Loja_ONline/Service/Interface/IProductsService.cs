using Loja_ONline.Entities.ViewModel;

namespace Loja_ONline.Service.Interface
{
    public interface IProductsService
    {
        List<ProductsViewModel> GetAll();
    }
}
