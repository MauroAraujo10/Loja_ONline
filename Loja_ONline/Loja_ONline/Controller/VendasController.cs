using Loja_ONline.Entities.ViewModel.Vendas;
using Loja_ONline.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Loja_ONline.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class VendasController : ControllerBase
    {
        private readonly IVendasService _service;
        public VendasController(IVendasService service)
        {
            _service = service;
        }

        /// <summary>
        /// Retornar uma lista com todas as vendas
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(VendasGetDto))]
        public async Task<IActionResult> GetAll(CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();
            
            var vendas = await _service.GetAll();
            return Ok(vendas);
        }

        /// <summary>
        /// Retorna uma venda
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(VendasGetDto))]
        public async Task<IActionResult> GetById(string id, CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();

            var venda = await _service.GetById(id);
            return Ok(venda);
        }

        /// <summary>
        /// Adiciona uma nova venda
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(VendasPostDto))]
        public async Task<IActionResult> Create(VendasPostDto dto, CancellationToken ct)
        {
            ct.ThrowIfCancellationRequested();

            await _service.Create(dto);
            return Created("/Vendas", dto);
        }
        
        /// <summary>
        /// Atualiza uma venda
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(VendasPostDto))]
        public async Task<IActionResult> Update(string id, VendasPostDto dto, CancellationToken ct)
        {
            ct.ThrowIfCancellationRequested();

            await _service.Update(id, dto);
            return Ok();
        }
        
        /// <summary>
        /// Deleta uma venda
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Deleta(string id, CancellationToken ct)
        {
            ct.ThrowIfCancellationRequested();

            await _service.Delete(id);
            return Ok();
        }
    }
}
