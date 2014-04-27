using System.Runtime.Serialization;

namespace pt12lolMvc4Application.Db.Models
{
    [DataContract]
    public class webpages_OAuthMembership
    {
        [DataMember] public string Provider { get; set; }
        [DataMember] public string ProviderUserId { get; set; }
        [DataMember] public int UserId { get; set; }

        public virtual UserProfile UserProfile { get; set; }
    }
}
