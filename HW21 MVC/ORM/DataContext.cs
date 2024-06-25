using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace ORM
{
    public class DataContext : IdentityDbContext<IdentityUser>
    {
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="options"></param>
        public DataContext(DbContextOptions<DataContext> options):
            base(options)
        { }

        public DbSet<Notes> Notes { get; set; }//Set of Notes from data base

        protected override void OnModelCreating(ModelBuilder builder)
        {
            
            //Create admin for site
            //1) Create user role admin
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole()
                {
                    Id = "7a982c4d-b6d9-4fd6-9937-f67761feffe7",
                    Name = "admin",
                    NormalizedName = "Admin"                    
                },
                new IdentityRole()
                { 
                    Id= "bd326530-8a0a-4a88-bfac-d12a501810f4",
                    Name="user",
                    NormalizedName="User"
                }
                );
            //Create Admin User
            builder.Entity<IdentityUser>().HasData(
                new IdentityUser()
                {
                    Id = "946574fd-bb30-462f-83a4-3a77fc0d8fed",
                    UserName = "admin",
                    NormalizedUserName = "Admin",
                    Email = "adminEmail@gmail.com",
                    NormalizedEmail = "ADMINEMAIL@gmail.com",
                    EmailConfirmed = true,
                    PasswordHash = new PasswordHasher<IdentityUser>()
                    .HashPassword(null, "superpassword"),
                    SecurityStamp = String.Empty
                }
                );

            //Bind User role admin and user admin by Guids

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>()
                { 
                    UserId = "946574fd-bb30-462f-83a4-3a77fc0d8fed",
                    RoleId= "7a982c4d-b6d9-4fd6-9937-f67761feffe7"
                }
                );

            base.OnModelCreating(builder);
        }


    }
}
