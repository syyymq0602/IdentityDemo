using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BooksAppStore.Data;
using Volo.Abp.DependencyInjection;

namespace BooksAppStore.EntityFrameworkCore
{
    public class EntityFrameworkCoreBooksAppStoreDbSchemaMigrator
        : IBooksAppStoreDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreBooksAppStoreDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the BooksAppStoreMigrationsDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<BooksAppStoreMigrationsDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}