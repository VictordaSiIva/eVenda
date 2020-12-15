using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StockService.Controllers.Converters.Implementations;
using StockService.Repository.Implementations;
using StockService.Services.Implementations;
using StockService.Services.Implementations.Converter;

namespace StockService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<Repository.Abstracts.IProductRepository, EntityFrameworkProductRepository>(opt => opt.UseInMemoryDatabase("service"))
                .AddScoped<Controllers.Converters.Abstracts.IFactory, ConverterFactory>()
                .AddScoped<Services.Abstracts.Converter.IModelJSONConverter, ModelJSONConverter>()
                .AddScoped<Services.Abstracts.Converter.IModelByteConverter, ModelByteConverter>()
                .AddScoped<Repository.Abstracts.IUnitOfWork, UnitOfWork>()
                .AddScoped<Services.Abstracts.INotifyService, AzureServiceBusNotifyService>()
                .AddScoped<Services.Abstracts.IProductService, ProductService>()
                .AddScoped<Services.Abstracts.INotifiedService, AzureServiceBusNotifiedService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, Services.Abstracts.INotifiedService notified)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            notified.StartListen();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
