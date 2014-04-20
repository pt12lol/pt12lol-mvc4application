using System.Data.Entity;
using System.Data.Entity.SqlServerCompact;

namespace pt12lolMvc4Application.Db.Repositories
{
    class EntitiesConfiguration : DbConfiguration
    {
        public EntitiesConfiguration()
        {
            SetProviderServices(SqlCeProviderServices.ProviderInvariantName, SqlCeProviderServices.Instance);
        }
    }
}
