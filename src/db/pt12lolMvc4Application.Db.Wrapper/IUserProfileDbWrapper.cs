using pt12lolMvc4Application.Db.Models;

namespace pt12lolMvc4Application.Db.Wrapper
{
    public interface IUserProfileDbWrapper
    {
        UserProfile GetUserProfileByName(string name);
        void AddUser(UserProfile toAdd);
    }
}
