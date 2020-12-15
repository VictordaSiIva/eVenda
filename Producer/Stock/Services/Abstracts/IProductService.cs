using StockService.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockService.Services.Abstracts
{
    public interface IProductService
    {
        Task<Models.OperationResult> UpdateAsync(Product model);
        Task<IEnumerable<Models.Product>> GetAllAsync();
        Task<Models.OperationResult> CreateAsync(Product model);
        Task<Models.OperationResult> UpdateStockAsync(string productId, decimal amount);
    }
}
