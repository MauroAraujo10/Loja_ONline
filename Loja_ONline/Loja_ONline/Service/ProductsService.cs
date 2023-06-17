using Loja_ONline.Entities.ViewModel;
using Loja_ONline.Service.Interface;

namespace Loja_ONline.Service
{
    public class ProductsService : IProductsService
    {
        public ProductsService()
        {

        }
        public List<ProductsViewModel> GetAll()
        {
            return new List<ProductsViewModel>();
        }
    }
}
