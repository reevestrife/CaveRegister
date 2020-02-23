using CaveRegister.MongoDB;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace CaveRegister.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(CaveRegisterMongoDbModule),
        typeof(CaveRegisterApplicationContractsModule)
        )]
    public class CaveRegisterDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
