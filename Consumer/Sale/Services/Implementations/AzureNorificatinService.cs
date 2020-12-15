using Microsoft.Azure.ServiceBus;
using SaleService.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SaleService.Services.Implementations
{
    public class AzureNorificatinService : Abstracts.INotifiedService
    {
        private const string connectionString = "_connectionString_";
        private const string subscription = "SaleService";

        private const string creation_key = "Produto Criado";
        private const string update_key =   "Produto Atualizado";

        private Abstracts.IProductService productService;
        private SubscriptionClient _createdServiceBusClient = new SubscriptionClient(connectionString, creation_key, update_key);
        public AzureNorificatinService(Abstracts.IProductService productService)
        {
            this.productService = productService;
            var messageHandlerOptions = new MessageHandlerOptions(ExceptionReceivedHandler)
            {
                MaxConcurrentCalls = 1,
                AutoComplete = false
            };

            this._createdServiceBusClient.RegisterMessageHandler(ProcessCreateproductMessageAsync, messageHandlerOptions);
        }

        private Task ProcessCreateproductMessageAsync(Message message, CancellationToken arg2)
        {
            var product = message.Body.ParseJson<Models.Product>();
            this.productService.Create(product);
            return Task.CompletedTask;
        }

        private Task ExceptionReceivedHandler(ExceptionReceivedEventArgs arg)
        {
            throw new NotImplementedException();
        }
    }
}
