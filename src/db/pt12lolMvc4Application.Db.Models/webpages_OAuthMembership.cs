namespace pt12lolMvc4Application.Db.Models
{
    public class webpages_OAuthMembership
    {
        public string Provider { get; set; }
        public string ProviderUserId { get; set; }
        public int UserId { get; set; }

        public virtual UserProfile UserProfile { get; set; }
    }
}
