using System.Data.Entity;
using System.Linq;

namespace pt12lolMvc4Application.Db.Repositories
{
    public static class pt12lolConfigurator
    {
        public static void InitializeDbConnection()
        {
            using (DbContext context = new EntitiesContext())
            {
                context.Database.Connection.Open();
            }
        }
    }
}
