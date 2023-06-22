using Loja_ONline.Entities.ViewModel.Usuarios;

namespace Loja_ONline.Service.Interface
{
    public interface IUsuariosService
    {
        Task<List<UsuariosGetDto>> GetAll();
    }
}
