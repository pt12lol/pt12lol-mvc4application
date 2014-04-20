using AutoMapper;

namespace pt12lolMvc4Application.Db.Service.ClassLib
{
    public static class pt12lolConfigurator
    {
        public static void ConfigureAutoMapper()
        {
            Mapper.CreateMap<Repositories.UserProfile, Models.UserProfile>();
            Mapper.CreateMap<Repositories.webpages_Membership, Models.webpages_Membership>();
            Mapper.CreateMap<Repositories.webpages_OAuthMembership, Models.webpages_OAuthMembership>();
            Mapper.CreateMap<Repositories.webpages_Roles, Models.webpages_Roles>();

            Mapper.CreateMap<Models.UserProfile, Repositories.UserProfile>();
            Mapper.CreateMap<Models.webpages_Membership, Repositories.webpages_Membership>();
            Mapper.CreateMap<Models.webpages_OAuthMembership, Repositories.webpages_OAuthMembership>();
            Mapper.CreateMap<Models.webpages_Roles, Repositories.webpages_Roles>();
        }
        public static void InitializeDbConnection()
        {
            Repositories.pt12lolConfigurator.InitializeDbConnection();
        }
    }
}
