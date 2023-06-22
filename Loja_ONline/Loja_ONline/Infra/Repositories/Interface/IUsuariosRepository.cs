using Loja_ONline.Entities;

namespace Loja_ONline.Infra.Repositories.Interface
{
    public interface IUsuariosRepository
    {
        Task<List<Usuarios>> GetAll();
    }
}
