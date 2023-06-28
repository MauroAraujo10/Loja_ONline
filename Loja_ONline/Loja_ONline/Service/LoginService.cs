using Loja_ONline.Entities;
using Loja_ONline.Entities.ViewModel.Login;
using Loja_ONline.Infra.Repositories.Interface;
using Loja_ONline.Service.Interface;

namespace Loja_ONline.Service
{
    public class LoginService : ILoginService
    {
        private readonly IConfiguration _configuration;
        private readonly ILoginRepository _repository;
        public LoginService(IConfiguration configuration, ILoginRepository repository)
        {
            _configuration = configuration;
            _repository = repository;
        }

        public async Task<Usuarios?> GetUserByLogin(LoginViewModel loginViewModel)
        {
            return await _repository.GetUserByLogin(loginViewModel);
        }

        public async Task<string> GenerateToken(Usuarios usuario)
        {
            var secret = _configuration.GetSection("TokenManagement:Secret").Value.ToString();
            return TokenService.GenerateToken(usuario, secret);
        }
    }
}
