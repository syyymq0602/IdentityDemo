using PumpData.MongoDB;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace PumpData.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(PumpDataMongoDbModule),
        typeof(PumpDataApplicationContractsModule)
        )]
    public class PumpDataDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
