using CaveRegister.MongoDB;
using Volo.Abp.Modularity;

namespace CaveRegister
{
    [DependsOn(
        typeof(CaveRegisterMongoDbTestModule)
        )]
    public class CaveRegisterDomainTestModule : AbpModule
    {

    }
}