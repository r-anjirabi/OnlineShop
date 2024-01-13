using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.ApplicationServices;
using OnlineShop.ApplicationServices.Setting;
using OnlineShop.Domain.Aggregates.OrderAggregate;
using OnlineShop.Domain.Entities.Customer;
using OnlineShop.Domain.Entities.Product;
using OnlineShop.Infrastructure;
using OnlineShop.Infrastructure.Repositories;

namespace OnlineShop.Configuration
{
    internal static class CompositionRoot
    {
        public static void Initialize(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("OrderDb");
            services.AddDbContext<OrderingContext>(opt => opt.UseSqlServer(connectionString));

            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IProductService, ProductService>();

            services.AddSingleton<IOrderSetting>(sp =>
            {
                var orderSetting = configuration.GetSection("OrderSetting");
                return new OrderSetting()
                {
                    MinimumOrderPrice = decimal.Parse(orderSetting["MinimumOrderPrice"]),
                    OrderingEndHour = int.Parse(orderSetting["OrderingEndHour"]),
                    OrderingStartHour = int.Parse(orderSetting["OrderingStartHour"])
                };
            });


        }
    }
}
