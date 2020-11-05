using System.Threading.Tasks;

namespace PumpData.Data
{
    public interface IPumpDataDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
