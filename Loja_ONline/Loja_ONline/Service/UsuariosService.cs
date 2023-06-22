using Loja_ONline.Entities.ViewModel.Usuarios;
using Loja_ONline.Infra.Repositories.Interface;
using Loja_ONline.Service.Interface;

namespace Loja_ONline.Service
{
    public class UsuariosService : IUsuariosService
    {
        private readonly IUsuariosRepository _repository;
        public UsuariosService(IUsuariosRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<List<UsuariosGetDto>> GetAll()
        {
            var usuarios = await _repository.GetAll();
            var listUsuarios = new List<UsuariosGetDto>();

            foreach (var usuario in usuarios)
            {
                listUsuarios.Add(new UsuariosGetDto
                {
                    IdUsuario = Guid.Parse(usuario.IdUsuario),
                    Sexo = usuario.Sexo,
                    DataNascimento = usuario.DataNascimento,
                    Nome = usuario.Nome,
                    Login = usuario.Login,
                    Senha = usuario.Senha
                });
            }

            return listUsuarios;
        }
    }
}
