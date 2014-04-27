using System.ServiceModel;
using pt12lolMvc4Application.Db.Models;

namespace pt12lolMvc4Application.Db.Service.WCF
{
    [ServiceContract]
    public interface IUserProfileDbService
    {
        [OperationContract] UserProfile GetUserProfileByUserName(string name);
        [OperationContract] webpages_Membership GetMembershipByUserName(string userName);
        [OperationContract] string GetPasswordSaltByUserName(string userName);
        [OperationContract] void AddUser(UserProfile toAdd);
        [OperationContract] void UpdateMembership(webpages_Membership toUpdate);
    }
}
