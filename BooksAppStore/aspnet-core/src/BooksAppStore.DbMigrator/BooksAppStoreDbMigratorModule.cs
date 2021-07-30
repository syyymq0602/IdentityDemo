using BooksAppStore.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace BooksAppStore.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(BooksAppStoreEntityFrameworkCoreDbMigrationsModule),
        typeof(BooksAppStoreApplicationContractsModule)
        )]
    public class BooksAppStoreDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
