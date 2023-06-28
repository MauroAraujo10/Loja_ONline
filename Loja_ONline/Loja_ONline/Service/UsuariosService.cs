using Loja_ONline.Entities;
using Loja_ONline.Entities.ViewModel.Usuarios;
using Loja_ONline.Infra.Repositories.Interface;
using Loja_ONline.Service.Interface;

namespace Loja_ONline.Service
{
    public class UsuariosService : IUsuariosService
    {
        private readonly IUsuariosRepository _repository;
        private readonly IPerfilUsuarioRepository _perfilUsuarioRepository;
        public UsuariosService(IUsuariosRepository repository, IPerfilUsuarioRepository perfilUsuarioRepository)
        {
            _repository = repository;
            _perfilUsuarioRepository = perfilUsuarioRepository;
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
                    Nome = usuario.Nome,
                    DataNascimento = usuario.DataNascimento,
                    Perfil = usuario.PerfilUsuario.Perfil,
                    CPF = usuario.CPF,
                    Sexo = usuario.Sexo,
                    Login = usuario.Login,
                    Senha = usuario.Senha
                });
            }

            return listUsuarios;
        }

        public async Task<UsuariosGetDto> GetById(string id)
        {
            var usuario = await _repository.GetById(id);

            if (usuario != null)
                return new UsuariosGetDto
                {
                    IdUsuario = Guid.Parse(usuario.IdUsuario),
                    Nome = usuario.Nome,
                    DataNascimento = usuario.DataNascimento,
                    Perfil = usuario.PerfilUsuario.Perfil,
                    CPF = usuario.CPF,
                    Sexo = usuario.Sexo,
                    Login = usuario.Login,
                    Senha = usuario.Senha
                };

            return null;
        }

        public async Task Create(UsuarioPostDto dto)
        {
            var idPerfil = await _perfilUsuarioRepository.Get_Id_Perfil_Usuario();

            var usuario = new Usuarios
            {
                IdUsuario = Guid.NewGuid().ToString(),
                IdPerfil = idPerfil,
                Nome = dto.Nome,
                DataNascimento = dto.DataNascimento,
                CPF = dto.CPF,
                Sexo = dto.Sexo,
                Login = dto.Login,
                Senha = dto.Senha
            };

            await _repository.Create(usuario);
        }

        public async Task Update(string id, UsuarioPostDto dto)
        {
            var usuario = await _repository.GetById(id);

            if (usuario != null)
            {
                usuario.Nome = dto.Nome;
                usuario.DataNascimento = dto.DataNascimento;
                usuario.CPF = dto.CPF;
                usuario.Sexo = dto.Sexo;
                usuario.Login = dto.Login;
                usuario.Senha = dto.Senha;

                await _repository.Update(usuario);
            }
        }

        public async Task Delete(string id)
        {
            var usuario = await _repository.GetById(id);

            if (usuario != null)
                await _repository.Delete(usuario);
        }
    }
}
