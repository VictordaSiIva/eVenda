using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaleService.Controllers.Converters;
using SaleService.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService product, INotifiedService notified)
        {
            this._productService = product;
        }

        [HttpGet]
        public IEnumerable<Models.Produto> Get()
        {
       
            return this._productService.Get().Select(f => (Models.Produto)f.FromModel());
        }
    }
}
