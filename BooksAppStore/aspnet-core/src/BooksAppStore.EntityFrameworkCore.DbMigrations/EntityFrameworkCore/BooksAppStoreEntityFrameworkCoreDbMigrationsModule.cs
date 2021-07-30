using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace BooksAppStore.EntityFrameworkCore
{
    [DependsOn(
        typeof(BooksAppStoreEntityFrameworkCoreModule)
        )]
    public class BooksAppStoreEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<BooksAppStoreMigrationsDbContext>();
        }
    }
}
