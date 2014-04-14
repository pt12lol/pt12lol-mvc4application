using pt12lolMvc4Application.Db.Models;

namespace pt12lolMvc4Application.Db.Service.ClassLib
{
    public interface IUserProfileDbService
    {
        UserProfile GetUserProfileByName(string name);
        void AddUser(UserProfile toAdd);
    }
}
