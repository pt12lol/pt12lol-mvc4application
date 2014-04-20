using pt12lolMvc4Application.Db.Models;

namespace pt12lolMvc4Application.Db.Wrapper
{
    public interface IUserProfileDbWrapper
    {
        UserProfile GetUserProfileByName(string name);
        void AddUser(UserProfile toAdd);
        string GetSaltByName(string name);
        void UpdateMemberfship(webpages_Membership toUpdate);
        webpages_Membership GetMembershipByUserName(string userName);
    }
}
