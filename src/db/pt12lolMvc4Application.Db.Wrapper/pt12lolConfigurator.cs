﻿namespace pt12lolMvc4Application.Db.Wrapper
{
    public static class pt12lolConfigurator
    {
        public static void ConfigureAutoMapper()
        {
            Service.ClassLib.pt12lolConfigurator.ConfigureAutoMapper();
        }
        public static void InitializeDbConnection()
        {
            Service.ClassLib.pt12lolConfigurator.InitializeDbConnection();
        }
    }
}
