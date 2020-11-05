using PumpData.MongoDB;
using Volo.Abp.Modularity;

namespace PumpData
{
    [DependsOn(
        typeof(PumpDataMongoDbTestModule)
        )]
    public class PumpDataDomainTestModule : AbpModule
    {

    }
}