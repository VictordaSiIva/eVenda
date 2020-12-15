using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockService.Services.Abstracts
{
    public interface INotifyService
    {
        public Task Send(string niotificationTitle, IModel notificationData);
    }
}
