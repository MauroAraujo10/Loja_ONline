using Loja_ONline.Entities;
using Loja_ONline.Entities.ViewModel.Login;

namespace Loja_ONline.Infra.Repositories.Interface
{
    public interface ILoginRepository
    {
        Task<Usuarios?> GetUserByLogin(LoginViewModel loginViewModel);
    }
}
