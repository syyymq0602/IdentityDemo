using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace BooksAppStore.Data
{
    /* This is used if database provider does't define
     * IBooksAppStoreDbSchemaMigrator implementation.
     */
    public class NullBooksAppStoreDbSchemaMigrator : IBooksAppStoreDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}