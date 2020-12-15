using StockService.Controllers.Models;
using StockService.Models;

namespace StockService.Controllers.Converters.Implementations
{
    public class ProdutoProductConverter: Abstracts.IModelControllerModelConverter<Product, Produto>
    {
        public Produto FromModel(Product product)
        {
            return new Produto()
            {
                Id = product.Id,
                Codigo = product.Code,
                Nome = product.Name,
                Preco = product.Price,
                QuantidadeEmEstoque = product.Stock
            };
        }

        public Product ToModel(Produto product)
        {
            return new Product()
            {
                Id = product.Id,
                Code = product.Codigo,
                Name = product.Nome,
                Price = product.Preco,
                Stock = product.QuantidadeEmEstoque
            };
        }
    }
}
