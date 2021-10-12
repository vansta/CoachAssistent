using CoachAssistent.Data.SeedingLibrary;
using CoachAssistent.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace CoachAssistent.Data
{
    public class CoachAssistentDbContext : DbContext
    {
        public CoachAssistentDbContext(DbContextOptions<CoachAssistentDbContext> options)
        : base(options)
        {
        }

        #region DbSets
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Credential> Credentials { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<JoinRequest> JoinRequests { get; set; }
        #endregion DbSets
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                RoleLibrary.Admin,
                RoleLibrary.Coach,
                RoleLibrary.Player
                );

            modelBuilder.Entity<Permission>().HasData(
                PermissionLibrary.CreateGroup,
                PermissionLibrary.CreateUser
                );

            modelBuilder.Entity<UserType>().HasData(
                UserTypeLibrary.Free
                );

            base.OnModelCreating(modelBuilder);
        }

    }
}
