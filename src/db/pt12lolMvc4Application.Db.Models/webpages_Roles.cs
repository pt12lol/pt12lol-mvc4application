using System.Collections.Generic;

namespace pt12lolMvc4Application.Db.Models
{
    public class webpages_Roles : IDbModel
    {
        public webpages_Roles()
        {
            UserProfiles = new HashSet<UserProfile>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<UserProfile> UserProfiles { get; set; }
    }
}
