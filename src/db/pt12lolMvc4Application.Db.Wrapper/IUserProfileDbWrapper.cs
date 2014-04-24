using pt12lolMvc4Application.Db.Models;

namespace pt12lolMvc4Application.Db.Wrapper
{
    public interface IUserProfileDbWrapper
    {
        UserProfile GetUserProfileByUserName(string name);
        void AddUser(UserProfile toAdd);
        string GetPasswordSaltByName(string name);
        void UpdateMembership(webpages_Membership toUpdate);
        webpages_Membership GetMembershipByUserName(string userName);
    }
}
