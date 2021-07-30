using BooksAppStore.DomainBooks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace BooksAppStore.EntityFrameworkCore
{
    public static class BooksAppStoreDbContextModelCreatingExtensions
    {
        public static void ConfigureBooksAppStore(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(BooksAppStoreConsts.DbTablePrefix + "YourEntities", BooksAppStoreConsts.DbSchema);
            //    b.ConfigureByConvention(); //auto configure for the base class props
            //    //...
            //});
            
            builder.Entity<Book>(b =>
            {
                b.ToTable(BooksAppStoreConsts.DbTablePrefix + "Books",
                    BooksAppStoreConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props
                b.Property(x => x.Name).IsRequired().HasMaxLength(128);
            });
        }
    }
}