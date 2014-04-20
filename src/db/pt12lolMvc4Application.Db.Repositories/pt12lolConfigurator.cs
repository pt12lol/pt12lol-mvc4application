using System.Linq;

namespace pt12lolMvc4Application.Db.Repositories
{
    public static class pt12lolConfigurator
    {
        public static void InitializeDbConnection()
        {
            bool any = new Entities().UserProfiles.Any();
        }
    }
}
