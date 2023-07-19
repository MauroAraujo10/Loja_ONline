using Loja_ONline.Entities;

namespace Loja_ONline.Infra.Repositories.Interface
{
    public interface IUsuariosRepository
    {
        Task<List<Usuarios>> GetAll();
        Task<Usuarios?> GetByLogin(string login);
        Task<Usuarios?> GetById(string id);
        Task Create(Usuarios usuario);
        Task Update(Usuarios usuario);
        Task Delete(Usuarios usuario);
    }
}
