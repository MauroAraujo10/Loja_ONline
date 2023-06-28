using Loja_ONline.Entities.ViewModel.Produtos;
using Loja_ONline.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Loja_ONline.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly IProductsService _service;
        private readonly ILogger<ProdutosController> _logger;
        public ProdutosController(IProductsService service, ILogger<ProdutosController> logger)
        {
            _service = service;
            _logger = logger;
        }

        /// <summary>
        /// Retorna uma lista com todos os produtos
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProdutosGetDto))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAll(CancellationToken ct = default)
        {
            _logger.LogInformation("Requisição recebida com sucesso");
            ct.ThrowIfCancellationRequested();

            var result = await _service.GetAll();

            if (!result.Any())
                return NoContent();

            return Ok(result);
        }

        /// <summary>
        /// Retornar um produto
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProdutosGetDto))]
        public async Task<IActionResult> GetById(string id, CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();

            var produto = await _service.GetById(id);
            return Ok(produto);
        }


        /// <summary>
        /// Adicona um novo produto
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "Administrador, Vendedor")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ProdutosPostDto))]
        public async Task<IActionResult> Create([FromBody]ProdutosPostDto dto, CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();

            await _service.Create(dto);
            return Created("/Produtos", dto);
        }
        
        /// <summary>
        /// Atualiza um produto
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        [HttpPut]
        [Authorize(Roles = "Administrador, Vendedor")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Update(string id, [FromBody]ProdutosPostDto dto, CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();

            await _service.Update(id, dto);
            return Ok();
        }
        
        /// <summary>
        /// Deleta um produto
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        [HttpDelete]
        [Authorize(Roles = "Administrador, Vendedor")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(string id, CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();

            await _service.Delete(id);
            return Ok();
        }
    }
}
