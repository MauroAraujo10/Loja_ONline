using Loja_ONline.Entities.ViewModel.Vendedor;
using Loja_ONline.Infra.Repositories.Interface;
using Loja_ONline.Service.Interface;

namespace Loja_ONline.Service
{
    public class VendedorService : IVendedorService
    {
        private readonly IVendedorRepository _repository;

        public VendedorService(IVendedorRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<VendedorGetDto>> GetAll()
        {
            var vendedores = await _repository.GetAll();
            var listVendedores = new List<VendedorGetDto>();

            foreach (var vendedor in vendedores)
            {
                listVendedores.Add(new VendedorGetDto
                {
                    IdVendedor = Guid.Parse(vendedor.IdVendedor),
                    IdUsuario = Guid.Parse(vendedor.IdUsuario),
                    Nome = vendedor.Usuario.Nome,
                    DataNascimento = vendedor.Usuario.DataNascimento,
                    QuantidadeVendas = vendedor.QuantidadeVendas,
                    Sexo = vendedor.Usuario.Sexo == 'M' ? "Masculino" : "Feminino",
                    Login = vendedor.Usuario.Login
                });
            }

            return listVendedores;
        }
    }
}
