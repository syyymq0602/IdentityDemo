using Volo.Abp.Modularity;

namespace BooksAppStore
{
    [DependsOn(
        typeof(BooksAppStoreApplicationModule),
        typeof(BooksAppStoreDomainTestModule)
        )]
    public class BooksAppStoreApplicationTestModule : AbpModule
    {

    }
}