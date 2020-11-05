using Volo.Abp.Modularity;

namespace PumpData
{
    [DependsOn(
        typeof(PumpDataApplicationModule),
        typeof(PumpDataDomainTestModule)
        )]
    public class PumpDataApplicationTestModule : AbpModule
    {

    }
}