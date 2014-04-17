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
        }
    }
}
