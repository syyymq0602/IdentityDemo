using System.Threading.Tasks;

namespace BooksAppStore.Data
{
    public interface IBooksAppStoreDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
