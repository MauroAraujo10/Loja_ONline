﻿using Loja_ONline.Entities.ViewModel.Produtos;
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
        /// Retornar uma lista com todos os produtoss
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductsViewModel))]
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
    }
}
