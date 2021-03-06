﻿namespace SaleService.Controllers.Converters
{
    public interface IConverterToModel<T, W> where T : SaleService.Models.IModel where W : Models.IControllerModel
    {
        T ToModel(W ControllerModel);
        W FromModel(T Model);
    }
}
