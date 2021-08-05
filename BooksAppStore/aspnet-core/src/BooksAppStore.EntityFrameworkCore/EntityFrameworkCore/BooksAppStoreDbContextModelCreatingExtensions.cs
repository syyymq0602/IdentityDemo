using BooksAppStore.DomainAuthors;
using BooksAppStore.DomainBooks;
using BooksAppStore.DomainSharedAuthors;
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
                b.ConfigureByConvention(); 
                b.Property(x => x.Name).IsRequired().HasMaxLength(128);
                
                b.HasOne<Author>().WithMany().HasForeignKey(x => x.AuthorId).IsRequired();
            });
            
            builder.Entity<Author>(b =>
            {
                b.ToTable(BooksAppStoreConsts.DbTablePrefix + "Authors",
                    BooksAppStoreConsts.DbSchema);
    
                b.ConfigureByConvention();
    
                b.Property(x => x.Name)
                    .IsRequired()
                    .HasMaxLength(AuthorConsts.MaxNameLength);

                b.HasIndex(x => x.Name);
            });
        }
    }
}