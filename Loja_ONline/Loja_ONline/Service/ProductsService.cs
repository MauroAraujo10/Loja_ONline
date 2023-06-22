using Loja_ONline.Entities.ViewModel.Produtos;
using Loja_ONline.Infra.Repositories.Interface;
using Loja_ONline.Service.Interface;

namespace Loja_ONline.Service
{
    public class ProductsService : IProductsService
    {
        private readonly IProdutosRepository _repository;
        public ProductsService(IProdutosRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ProductsViewModel>> GetAll()
        {
            var products = await _repository.GetAll();
            var listProducts = new List<ProductsViewModel>();

            foreach (var product in products)
            {
                listProducts.Add(new ProductsViewModel
                {
                    IdProduto = Guid.Parse(product.IdProduto),
                    NomeVendedor = product.Vendedores.Usuario.Nome,
                    Imagem = product.Imagem,
                    Nome = product.Nome,
                    Preco = product.Preco,
                    DataCadastro = product.DataCadastro,
                    QuantidadeEstoque = product.QuantidadeEstoque,
                    Descricao = product.Descricao,
                    Status = product.Status
                });
            }
            return listProducts;
        }
    }
}
