using Loja_ONline.Entities;
using Loja_ONline.Entities.ViewModel.Vendas;
using Loja_ONline.Infra.Repositories.Interface;
using Loja_ONline.Service.Interface;

namespace Loja_ONline.Service
{
    public class VendasService : IVendasService
    {
        private readonly IVendasRepository _repository;

        public VendasService(IVendasRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<VendasGetDto>> GetAll()
        {
            var vendas = await _repository.GetAll();
            var listaVendas = new List<VendasGetDto>();

            foreach (var venda in vendas)
            {
                listaVendas.Add(new VendasGetDto
                {
                    IdVenda = venda.IdVenda,
                    IdProduto = venda.IdProduto,
                    DataVenda = venda.DataVenda,
                    NomeVendedor = venda.Produtos.Usuarios.Nome,
                    QuantidadeComprada = venda.QuantidadeComprada,
                    ValorPago = venda.ValorPago
                });
            }
            return listaVendas;
        }

        public async Task<VendasGetDto> GetById(string id)
        {
            var venda = await _repository.GetById(id);

            if (venda == null) return null;

            return new VendasGetDto
            {
                IdVenda = venda.IdVenda,
                IdProduto = venda.IdProduto,
                DataVenda = venda.DataVenda,
                NomeVendedor = venda.Produtos.Usuarios.Nome,
                QuantidadeComprada = venda.QuantidadeComprada,
                ValorPago = venda.ValorPago
            };
        }

        public async Task Create(VendasPostDto dto)
        {
            var venda = new Vendas
            {
                IdVenda = Guid.NewGuid().ToString(),
                IdProduto = dto.IdProduto.ToString(),
                DataVenda = DateTime.Now,
                QuantidadeComprada = dto.QuantidadeComprada,
                ValorPago = dto.ValorPago
            };

            await _repository.Create(venda);
        }

        public async Task Update(string id, VendasPostDto dto)
        {
            var venda = await _repository.GetById(id);

            venda.ValorPago = dto.ValorPago;
            venda.QuantidadeComprada = dto.QuantidadeComprada;
        }
        public async Task Delete(string id)
        {
            var venda = await _repository.GetById(id);

            await _repository.Delete(venda);
        }
    }
}
