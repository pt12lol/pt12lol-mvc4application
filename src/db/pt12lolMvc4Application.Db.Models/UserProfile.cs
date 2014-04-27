using System.Collections.Generic;
using System.Runtime.Serialization;

namespace pt12lolMvc4Application.Db.Models
{
    [DataContract]
    public class UserProfile
    {
        public UserProfile()
        {
            webpages_OAuthMembership = new HashSet<webpages_OAuthMembership>();
            webpages_Roles = new HashSet<webpages_Roles>();
        }

        [DataMember] public int UserId { get; set; }
        [DataMember] public string UserName { get; set; }

        public virtual ICollection<webpages_OAuthMembership> webpages_OAuthMembership { get; set; }
        public virtual webpages_Membership webpages_Membership { get; set; }
        public virtual ICollection<webpages_Roles> webpages_Roles { get; set; }

        public override bool Equals(object obj)
        {
            var item = (UserProfile)obj;
            return UserId == item.UserId && UserName.Equals(item.UserName);
        }

        public override int GetHashCode()
        {
            return UserId.GetHashCode() ^ UserName.GetHashCode();
        }
    }
}
