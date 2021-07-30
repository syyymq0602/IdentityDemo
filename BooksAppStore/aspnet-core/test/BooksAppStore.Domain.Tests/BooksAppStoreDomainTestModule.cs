using BooksAppStore.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace BooksAppStore
{
    [DependsOn(
        typeof(BooksAppStoreEntityFrameworkCoreTestModule)
        )]
    public class BooksAppStoreDomainTestModule : AbpModule
    {

    }
}