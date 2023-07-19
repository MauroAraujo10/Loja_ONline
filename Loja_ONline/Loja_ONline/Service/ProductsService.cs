using Loja_ONline.Entities;
using Loja_ONline.Entities.ViewModel.Produtos;
using Loja_ONline.Infra.Repositories.Interface;
using Loja_ONline.Service.Interface;
using Loja_ONline.Utils.Enums;

namespace Loja_ONline.Service
{
    public class ProductsService : IProductsService
    {
        private readonly IProdutosRepository _repository;
        private readonly IUsuariosRepository _usuariosRepository;
        public ProductsService(IProdutosRepository repository, IUsuariosRepository usuariosRepository)
        {
            _repository = repository;
            _usuariosRepository = usuariosRepository;
        }

        public async Task<List<ProdutosGetDto>> GetAll()
        {
            var produto = await _repository.GetAll();
            var listaProdutos = new List<ProdutosGetDto>();

            foreach (var product in produto)
            {
                listaProdutos.Add(new ProdutosGetDto
                {
                    IdProduto = Guid.Parse(product.IdProduto),
                    IdUsuario = Guid.Parse(product.Usuarios.IdUsuario),
                    Imagem = product.Imagem,
                    Nome = product.Nome,
                    Preco = product.Preco,
                    NomeVendedor = product.Usuarios.Nome,
                    DataCadastro = product.DataCadastro,
                    QuantidadeEstoque = product.QuantidadeEstoque,
                    Descricao = product.Descricao,
                    Status = product.Status == 0 ? Enum.GetName(StatusProduct.Inativo) : Enum.GetName(StatusProduct.Ativo)
                });
            }
            return listaProdutos;
        }

        public async Task<ProdutosGetDto> GetById(string id)
        {
            var produto = await _repository.GetById(id);

            if (produto == null) return null;

            return new ProdutosGetDto
            {
                IdProduto = Guid.Parse(produto.IdProduto),
                IdUsuario = Guid.Parse(produto.Usuarios.IdUsuario),
                Imagem = produto.Imagem,
                Nome = produto.Nome,
                Preco = produto.Preco,
                NomeVendedor = produto.Usuarios.Nome,
                DataCadastro = produto.DataCadastro,
                QuantidadeEstoque = produto.QuantidadeEstoque,
                Descricao = produto.Descricao,
                Status = produto.Status == 0 ? Enum.GetName(StatusProduct.Inativo) : Enum.GetName(StatusProduct.Ativo)
            };
        }

        public async Task Create(ProdutosPostDto dto)
        {
            var usuario = await _usuariosRepository.GetByLogin(dto.Login);

            if (usuario == null)
                return;

            var produto = new Produtos
            {
                IdProduto = Guid.NewGuid().ToString(),
                IdUsuario = usuario.IdUsuario,
                Imagem = dto.Imagem,
                Nome = dto.Nome,
                Preco = dto.Preco,
                DataCadastro = DateTime.Now,
                QuantidadeEstoque = dto.QuantidadeEstoque,
                Descricao = dto.Descricao,
                Status = dto.Status
            };

            await _repository.Create(produto);
        }

        public async Task Update(string id, ProdutosPostDto dto)
        {
            var produto = await _repository.GetById(id);

            produto.Imagem = dto.Imagem;
            produto.Nome = dto.Nome;
            produto.Preco = dto.Preco;
            produto.QuantidadeEstoque = dto.QuantidadeEstoque;
            produto.Descricao = dto.Descricao;
            produto.Status = dto.Status;

            await _repository.Update(produto);
        }

        public async Task Delete(string id)
        {
            var produto = await _repository.GetById(id);

            if (produto != null)
                await _repository.Delete(produto);
        }
    }
}
