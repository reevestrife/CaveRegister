using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace CaveRegister.Data
{
    /* This is used if database provider does't define
     * ICaveRegisterDbSchemaMigrator implementation.
     */
    public class NullCaveRegisterDbSchemaMigrator : ICaveRegisterDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}