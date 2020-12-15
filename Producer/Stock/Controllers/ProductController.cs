using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using StockService.Controllers.Converters;
using System.Threading.Tasks;

namespace StockService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly Services.Abstracts.IProductService _productService;
        private readonly Converters.Abstracts.IFactory _converterFactory;
        public ProductController(Services.Abstracts.IProductService productService, Converters.Abstracts.IFactory converterFactory)
        {
            this._converterFactory = converterFactory;
            this._productService = productService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Produto>>> GetAll()
        {
            try
            {
                return Ok((await this._productService.GetAllAsync()).Select(f => this._converterFactory.GetConverter<StockService.Models.Product, Models.Produto>().FromModel(f)));
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult<dynamic>> Create([FromBody] Models.Produto produto) 
        {
            try
            {
     
                var operationResult = await this._productService
                    .CreateAsync(this._converterFactory.GetConverter<StockService.Models.Product, Models.Produto>().ToModel(produto));
                if (!operationResult.Success)
                {
                    return StatusCode(400, operationResult.ErrorMessage);
                }
                return Ok(new { });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<dynamic>> Update(string id, [FromBody] Models.Produto produto) 
        {
            try
            {
                produto.Id = id;
                var operationResult = await this._productService
                    .UpdateAsync(this._converterFactory.GetConverter<StockService.Models.Product, Models.Produto>().ToModel(produto));
                if (!operationResult.Success)
                {
                    return StatusCode(400, operationResult.ErrorMessage);
                }
                return Ok(new { });
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
