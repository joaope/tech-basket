using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.DependencyInjection;
using TechBasket.DomainService;
using TechBasket.DomainService.Infrastructure;

namespace TechBasket.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddSingleton<IProductRepository, InMemoryProductRepository>()
                .AddSingleton<IOfferRepository, InMemoryOfferRepository>()
                .AddSingleton<IProductService, ProductService>()
                .AddSingleton<IBasketCalculatorService, BasketCalculatorService>()
                .AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app
                    .UseDeveloperExceptionPage()
                    .UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                    {
                        HotModuleReplacement = true
                    });
            }

            app
                .UseStaticFiles()
                .UseMvcWithDefaultRoute();
        }
    }
}
