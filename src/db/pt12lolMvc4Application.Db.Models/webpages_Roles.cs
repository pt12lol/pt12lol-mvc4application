using System.Collections.Generic;
using System.Runtime.Serialization;

namespace pt12lolMvc4Application.Db.Models
{
    public class webpages_Roles
    {
        public webpages_Roles()
        {
            UserProfiles = new HashSet<UserProfile>();
        }

        [DataMember] public int RoleId { get; set; }
        [DataMember] public string RoleName { get; set; }

        public virtual ICollection<UserProfile> UserProfiles { get; set; }
    }
}
