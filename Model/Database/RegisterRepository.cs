using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Database
{
    public static class RegisterRepository
    {
        public static void AddRepository(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<TimeLoggerContext>(x =>
            {
                x.UseNpgsql(connectionString, s => s.MigrationsAssembly(typeof(RegisterRepository).Namespace));
            }, ServiceLifetime.Transient);
        }
    }
}
