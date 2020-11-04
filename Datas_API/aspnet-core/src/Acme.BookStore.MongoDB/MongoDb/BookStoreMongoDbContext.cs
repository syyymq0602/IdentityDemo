using MongoDB.Driver;
using Acme.BookStore.Users;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;
using Acme.BookStore.Books;

namespace Acme.BookStore.MongoDB
{
    [ConnectionStringName("Default")]
    public class BookStoreMongoDbContext : AbpMongoDbContext
    {
        public IMongoCollection<AppUser> Users => Collection<AppUser>();
        // public IMongoCollection<Book> Books => Collection<Book>();
        public IMongoCollection<Datas> datas => Collection<Datas>();
        protected override void CreateModel(IMongoModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);
            
            modelBuilder.Entity<Datas>(b =>
            {
                b.CollectionName = "datas";
            });
            
            modelBuilder.Entity<AppUser>(b =>
            {
                /* Sharing the same "AbpUsers" collection
                 * with the Identity module's IdentityUser class. */
                b.CollectionName = "AbpUsers";
            });
        }
    }
}
