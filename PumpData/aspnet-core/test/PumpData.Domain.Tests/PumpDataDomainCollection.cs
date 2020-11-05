using PumpData.MongoDB;
using Xunit;

namespace PumpData
{
    [CollectionDefinition(PumpDataTestConsts.CollectionDefinitionName)]
    public class PumpDataDomainCollection : PumpDataMongoDbCollectionFixtureBase
    {

    }
}
