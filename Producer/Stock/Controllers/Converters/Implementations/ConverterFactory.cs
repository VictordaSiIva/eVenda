using Microsoft.EntityFrameworkCore.Metadata;
using StockService.Controllers.Converters.Abstracts;
using StockService.Controllers.Models;
using StockService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IModel = Microsoft.EntityFrameworkCore.Metadata.IModel;

namespace StockService.Controllers.Converters.Implementations
{
    public class ConverterFactory : Abstracts.IFactory
    {
        public IModelControllerModelConverter<T, W> GetConverter<T, W>() where T :IModel where W : IControllerModel
        {
            if (typeof(T).Equals(typeof(Product)))
            {
                if (typeof(W).Equals(typeof(Produto)))
                {
                    return (IModelControllerModelConverter<T, W>)(new ProdutoProductConverter());
                }
            }
            throw new Exception("Invalid Conversion");
        }
    }
}
