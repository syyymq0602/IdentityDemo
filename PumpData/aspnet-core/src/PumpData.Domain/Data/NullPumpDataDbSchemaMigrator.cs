using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace PumpData.Data
{
    /* This is used if database provider does't define
     * IPumpDataDbSchemaMigrator implementation.
     */
    public class NullPumpDataDbSchemaMigrator : IPumpDataDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}