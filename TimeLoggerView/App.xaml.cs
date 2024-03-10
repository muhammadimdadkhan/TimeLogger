using Microsoft.Extensions.DependencyInjection;
using Model.Database;
using Model.Interface;
using Model.Repository;
using Service.Interface;
using Service.Service;
using System.Configuration;
using System.Data;
using System.IO;
using System.Windows;

namespace TimeLoggerView
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; set; }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Configure services
            ConfigureServices();

        }


        private void ConfigureServices()
        {
           var Configuration = System.Configuration.ConfigurationManager.ConnectionStrings["TimeLoggerDatabase"].ConnectionString;
            var services = new ServiceCollection();
            services.AddRepository(Configuration);
            // Register services

            //services.AddScoped< TimeLoggerContext>();
            services.AddScoped<IRepository, EntityFrameworkRepository>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IUserService, UserService>();

            // Build service provider
            ServiceProvider = services.BuildServiceProvider();
        }
    }

}
