using SaleService.Models;
using System.Collections.Generic;

namespace SaleService.Services.Abstracts
{
    public interface IProductService
    {
        void Create(Product product);
        void Update(Product product);
        IEnumerable<Product> Get();
    }
}
