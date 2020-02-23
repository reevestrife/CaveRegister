using System.Threading.Tasks;

namespace CaveRegister.Data
{
    public interface ICaveRegisterDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
