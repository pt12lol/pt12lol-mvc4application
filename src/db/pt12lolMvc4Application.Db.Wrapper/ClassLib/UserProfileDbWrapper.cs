using pt12lolMvc4Application.Db.Service.ClassLib;

namespace pt12lolMvc4Application.Db.Wrapper.ClassLib
{
    public class UserProfileDbWrapper : IUserProfileDbWrapper
    {
        readonly IUserProfileDbService _service;

        public UserProfileDbWrapper()
        {
            _service = new UserProfileDbService();
        }

        public UserProfileDbWrapper(IUserProfileDbService service)
        {
            _service = service;
        }

        public Models.UserProfile GetUserProfileByName(string name)
        {
            return _service.GetUserProfileByName(name);
        }

        public void AddUser(Models.UserProfile toAdd)
        {
            _service.AddUser(toAdd);
        }

        public string GetSaltByName(string name)
        {
            return _service.GetSaltByUserName(name);
        }
    
        public void UpdateMemberfship(Models.webpages_Membership toUpdate)
        {
            _service.UpdateMembership(toUpdate);
        }

        public Models.webpages_Membership GetMembershipByUserName(string userName)
        {
            return _service.GetMembershipByUserName(userName);
        }
    }
}
