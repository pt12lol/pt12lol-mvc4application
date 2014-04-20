using pt12lolMvc4Application.Db.Models;

namespace pt12lolMvc4Application.Db.Service.ClassLib
{
    public interface IUserProfileDbService
    {
        UserProfile GetUserProfileByName(string name);
        void AddUser(UserProfile toAdd);
        string GetSaltByUserName(string name);
        void UpdateMembership(webpages_Membership toUpdate);
        webpages_Membership GetMembershipByUserName(string userName);
    }
}
