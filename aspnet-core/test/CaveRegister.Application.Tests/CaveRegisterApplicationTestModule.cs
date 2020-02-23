using Volo.Abp.Modularity;

namespace CaveRegister
{
    [DependsOn(
        typeof(CaveRegisterApplicationModule),
        typeof(CaveRegisterDomainTestModule)
        )]
    public class CaveRegisterApplicationTestModule : AbpModule
    {

    }
}