using Loja_ONline.Entities.ViewModel.Login;
using Loja_ONline.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Loja_ONline.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _service;

        public LoginController(ILoginService service)
        {
            _service = service;
        }

        /// <summary>
        /// Retorna um token baseado no login
        /// </summary>
        /// <param name="loginViewModel"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TokenGetDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Authenticate([FromBody] LoginViewModel loginViewModel, CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();

            if (loginViewModel == null || string.IsNullOrEmpty(loginViewModel.Login) || string.IsNullOrEmpty(loginViewModel.Password))
                return BadRequest();

            var usuario = await _service.GetUserByLogin(loginViewModel);

            if (usuario == null)
                return NotFound();

            var token = await _service.GenerateToken(usuario);

            if (string.IsNullOrEmpty(token))
                return NotFound();

            return Ok(new TokenGetDto
            {
                Token = token,
                Login = usuario.Login
            });
        }
    }
}
