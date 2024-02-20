using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Model.ModelSql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Database
{
    public class TimeLoggerContext : DbContext
    {
        public TimeLoggerContext(DbContextOptions<TimeLoggerContext> options) : base(options)
        {
            //key = _configuration["DatabaseEncryption:Key"];
        }
        public TimeLoggerContext() : base()
        {
        }

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
            optionsBuilder.UseNpgsql(ConfigurationManager.ConnectionStrings["TimeLoggerDatabase"].ConnectionString);
        }
    }
}
