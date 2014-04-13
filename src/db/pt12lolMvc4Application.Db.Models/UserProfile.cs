using System.Collections.Generic;

namespace pt12lolMvc4Application.Db.Models
{
    public class UserProfile : IDbModel
    {
        public UserProfile()
        {
            webpages_OAuthMembership = new HashSet<webpages_OAuthMembership>();
            webpages_Roles = new HashSet<webpages_Roles>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }

        public virtual ICollection<webpages_OAuthMembership> webpages_OAuthMembership { get; set; }
        public virtual webpages_Membership webpages_Membership { get; set; }
        public virtual ICollection<webpages_Roles> webpages_Roles { get; set; }
    }
}
