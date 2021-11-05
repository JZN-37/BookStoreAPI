using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookStoreAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        //Add UserID From SqlServer as Identity
        // ALTER TABLE [User] ADD UserID int identity

        public bool UStatus { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base("DefaultConnection", throwIfV1Schema: false)
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>().ToTable("User");

            modelBuilder.Entity<IdentityRole>().ToTable("Role");

            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRole");

            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaim");

            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogin");
        }
    }
}