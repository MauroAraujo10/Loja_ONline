using Loja_ONline.Entities.ViewModel.Vendedor;
using Loja_ONline.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Loja_ONline.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class VendedorController : ControllerBase
    {
        private readonly IVendedorService _service;
        public VendedorController(IVendedorService service)
        {
            _service = service;
        }

        /// <summary>
        /// Retornar uma lista com todos os vendedores
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(VendedorGetDto))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAll(CancellationToken ct)
        {
            ct.ThrowIfCancellationRequested();

            var result = await _service.GetAll();

            if (!result.Any())
                return NoContent();

            return Ok(result);
        }
    }
}
