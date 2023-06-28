using Loja_ONline.Entities;
using Loja_ONline.Entities.ViewModel.Login;
using Loja_ONline.Infra.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Loja_ONline.Infra.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly DataContext _dataContext;

        public LoginRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Usuarios?> GetUserByLogin(LoginViewModel loginViewModel)
        {
            return await _dataContext.Usuarios
                .Include(x => x.PerfilUsuario)
                .Where(x => x.Login == loginViewModel.Login && x.Senha == loginViewModel.Password)
                .FirstOrDefaultAsync();
        }
    }
}
