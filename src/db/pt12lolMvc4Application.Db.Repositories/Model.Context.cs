﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Diagnostics;

namespace pt12lolMvc4Application.Db.Repositories
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    partial class EntitiesContext : DbContext
    {
        public EntitiesContext()
            : base("name=EntitiesConnection")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual IDbSet<UserProfile> UserProfiles { get; set; }
        public virtual IDbSet<webpages_Membership> webpages_Membership { get; set; }
        public virtual IDbSet<webpages_OAuthMembership> webpages_OAuthMembership { get; set; }
        public virtual IDbSet<webpages_Roles> webpages_Roles { get; set; }
    }
}
