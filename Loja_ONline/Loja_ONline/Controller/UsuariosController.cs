using Loja_ONline.Entities.ViewModel.Usuarios;
using Loja_ONline.Service.Interface;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "Administrador")]
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

        /// <summary>
        /// Retorna um usuário
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Authorize(Roles = "Administrador")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(string id, CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();

            var usuario = await _service.GetById(id);

            if (usuario == null)
                return BadRequest();

            return Ok(usuario);
        }

        /// <summary>
        /// Adicona um novo usuário
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "Administrador")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromBody] UsuarioPostDto dto, CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();

            await _service.Create(dto);
            return Created("/Usuario", dto);
        }

        /// <summary>
        /// Atualiza um usuário
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        [HttpPut]
        [Authorize(Roles = "Administrador")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Update(string id, [FromBody] UsuarioPostDto dto, CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();

            await _service.Update(id, dto);
            return Ok();
        }

        /// <summary>
        /// Remove um usuário
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        [HttpDelete]
        [Authorize(Roles = "Administrador")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Remove([FromQuery] string id, CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();

            await _service.Delete(id);
            return Ok();
        }
    }
}
