using Loja_ONline.Entities.ViewModel;
using Loja_ONline.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Loja_ONline.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _service;
        private readonly ILogger<ProductsController> _logger;
        public ProductsController(IProductsService service, ILogger<ProductsController> logger)
        {
            _service = service;
            _logger = logger;
        }

        /// <summary>
        /// Retornar todos os produtos cadastrados
        /// </summary>
        /// <param name="ct">Cancellation Token</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductsViewModel))]
        public IActionResult GetAll(CancellationToken ct = default)
        {
            _logger.LogInformation("Requisição recebida com sucesso");
            ct.ThrowIfCancellationRequested();

            var result = _service.GetAll();

            return Ok(result);
        }
    }
}
