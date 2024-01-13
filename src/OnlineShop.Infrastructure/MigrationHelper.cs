using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace OnlineShop.Infrastructure
{
    internal static class DatabaseMigrationHelper
    {
        public static async Task<IServiceProvider> MigrateDatabaseAsync(this IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var db = services.GetRequiredService<OrderingContext>();
                    await db.Database.EnsureCreatedAsync();
                    await db.Database.MigrateAsync();
                }
                catch (Exception)
                {
                }
            }

            return serviceProvider;
        }
    }
}
