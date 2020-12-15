using SaleService.Controllers.Models;
using SaleService.Models;

namespace SaleService.Controllers.Converters
{
    public class ProductConverter : IConverterToModel<Product, Produto>
    {
        public Produto FromModel(Product product)
        {
            return new Produto()
            {
                ID = product.Id,
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
                Id = product.ID,
                Code = product.Codigo,
                Name = product.Nome,
                Price = product.Preco,
                Stock = product.QuantidadeEmEstoque
            };
        }
    }
}
