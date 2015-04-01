using Microsoft.AspNet.Identity.EntityFramework;

namespace briefcase
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using briefcase.Models;

    public class BriefcaseEntities : DbContext
    {
        // Your context has been configured to use a 'BriefcaseEntities' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'briefcase.BriefcaseEntities' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'BriefcaseEntities' 
        // connection string in the application configuration file.
        public BriefcaseEntities()
            : base("name=BriefcaseEntities")
        {
        }

        public static BriefcaseEntities Create()
        {
            return new BriefcaseEntities();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Post>()
               .HasRequired(c => c.User)
               .WithOptional()
               .WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>()
                .HasRequired(c => c.User)
                .WithOptional()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public DbSet<Post> Post { get; set; }
        public DbSet<Category> Category { get; set; }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }
    }
}