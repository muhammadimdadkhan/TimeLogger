using Microsoft.EntityFrameworkCore;
using Model.ModelSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Database
{
    public class TimeLoggerContext : DbContext
    {
        public DbSet<Audit> Audits { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<TimeLog> TimeLogs { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configure PostgreSQL connection string here
            optionsBuilder.UseNpgsql("YourPostgreSQLConnectionString");
        }
    }
}
