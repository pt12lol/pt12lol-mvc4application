using pt12lolMvc4Application.Db.Models;

namespace pt12lolMvc4Application.Db.Service.ClassLib
{
    public interface IUserProfileDbService
    {
        UserProfile GetUserProfileByUserName(string name);
        webpages_Membership GetMembershipByUserName(string userName);
        string GetPasswordSaltByUserName(string userName);
        void AddUser(UserProfile toAdd);
        void UpdateMembership(webpages_Membership toUpdate);
    }
}
