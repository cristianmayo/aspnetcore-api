using AspNetCore.API.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore.API.Infrastructure.Database
{
    public class SqlServerDbContext : DbContext
    {
        public SqlServerDbContext(DbContextOptions<SqlServerDbContext> options) : base(options)
        {
        }

        public DbSet<ApplicationRole> ApplicationRoles { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ClientApplication> ClientApplications { get; set; }
        public DbSet<ClientUserSession> ClientUserSessions { get; set; }
        public DbSet<UserRolePermission> UserRolePermissions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationRole>().ToTable("ApplicationRole");
            modelBuilder.Entity<ApplicationUser>().ToTable("ApplicationUser");
            modelBuilder.Entity<ClientApplication>().ToTable("ClientApplication");
            modelBuilder.Entity<ClientUserSession>().ToTable("ClientUserSession");
            modelBuilder.Entity<UserRolePermission>().ToTable("UserRolePermission");
        }
    }
}
