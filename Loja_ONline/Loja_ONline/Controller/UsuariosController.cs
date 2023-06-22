using Loja_ONline.Entities.ViewModel.Usuarios;
using Loja_ONline.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Loja_ONline.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuariosService _service;
        public UsuariosController(IUsuariosService service)
        {
            _service = service;
        }

        /// <summary>
        /// Retornar uma lista com todos os usuarios
        /// </summary>
        /// <param name="ct">Cancellation Token</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UsuariosGetDto))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAll(CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();

            var result = await _service.GetAll();

            if (!result.Any())
                return NoContent();

            return Ok(result);
        }
    }
}
