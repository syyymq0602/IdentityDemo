using MongoDB.Driver;
using PumpData.Books;
using PumpData.RealTimeParam;
using PumpData.Users;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace PumpData.MongoDB
{
    [ConnectionStringName("Default")]
    public class PumpDataMongoDbContext : AbpMongoDbContext
    {
        public IMongoCollection<AppUser> Users => Collection<AppUser>();
        public IMongoCollection<Parameter> Parameters => Collection<Parameter>();
        public IMongoCollection<Book> Books => Collection<Book>();

        protected override void CreateModel(IMongoModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);

            modelBuilder.Entity<Parameter>(b =>
            {
                b.CollectionName = "RealTimeParam";
            });
            modelBuilder.Entity<AppUser>(b =>
            {
                b.CollectionName = "AbpUsers";
            });
            modelBuilder.Entity<Book>(b =>
            {
                b.CollectionName = "datas";
            });
        }
    }
}
