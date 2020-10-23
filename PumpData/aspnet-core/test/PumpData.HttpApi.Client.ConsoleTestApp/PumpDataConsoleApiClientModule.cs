using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace PumpData.HttpApi.Client.ConsoleTestApp
{
    [DependsOn(
        typeof(PumpDataHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class PumpDataConsoleApiClientModule : AbpModule
    {
        
    }
}
