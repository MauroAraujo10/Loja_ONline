using Loja_ONline.Entities;
using Loja_ONline.Entities.ViewModel.Login;

namespace Loja_ONline.Service.Interface
{
    public interface ILoginService
    {
        Task<Usuarios?> GetUserByLogin(LoginViewModel loginViewModel);
        Task<string> GenerateToken(Usuarios usuario);
    }
}
