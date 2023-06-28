using Loja_ONline.Entities.ViewModel.Usuarios;

namespace Loja_ONline.Service.Interface
{
    public interface IUsuariosService
    {
        Task<List<UsuariosGetDto>> GetAll();
        Task<UsuariosGetDto> GetById(string id);
        Task Create(UsuarioPostDto dto);
        Task Update(string id, UsuarioPostDto dto);
        Task Delete(string id);
    }
}
