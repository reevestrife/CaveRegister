using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace CaveRegister.HttpApi.Client.ConsoleTestApp
{
    [DependsOn(
        typeof(CaveRegisterHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class CaveRegisterConsoleApiClientModule : AbpModule
    {
        
    }
}
