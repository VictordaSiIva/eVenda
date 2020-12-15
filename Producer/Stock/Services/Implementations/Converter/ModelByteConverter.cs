using StockService.Models;
using StockService.Services.Abstracts.Converter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockService.Services.Implementations.Converter
{
    public class ModelByteConverter : IModelByteConverter
    {
        private readonly UTF8Encoding Utf8NoBom = new UTF8Encoding(false);
        private Abstracts.Converter.IModelJSONConverter _jsonConverter;
        public ModelByteConverter(IModelJSONConverter jsonConverter)
        {
            this._jsonConverter = jsonConverter;
        }

        public string CotentType => "application/json";

        public T FromBytes<T>(byte[] data) where T : class
        {
            return this._jsonConverter.FromJSON<T>(Utf8NoBom.GetString(data));
        }

        public byte[] ToBytes(object model)
        {
            return Utf8NoBom.GetBytes(this._jsonConverter.ToJSON(model));
        }
    }
}
