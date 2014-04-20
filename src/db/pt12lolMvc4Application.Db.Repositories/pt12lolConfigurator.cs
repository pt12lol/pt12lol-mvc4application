using System.Data.Entity;
using System.Data.Entity.SqlServerCompact;

namespace pt12lolMvc4Application.Db.Repositories
{
    public static class pt12lolConfigurator
    {
        public static void InitializeDbConnection()
        {
            using (DbContext context = new Entities())
            {
                context.Database.Connection.Open();
            }
        }
    }
}
