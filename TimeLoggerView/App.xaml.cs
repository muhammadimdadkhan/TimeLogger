using Microsoft.Extensions.DependencyInjection;
using Service.Interface;
using Service.Service;
using System.Configuration;
using System.Data;
using System.Windows;

namespace TimeLoggerView
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Configure services
            ConfigureServices();

        }

        public IServiceProvider ServiceProvider { get; set; }

        private void ConfigureServices()
        {
            var services = new ServiceCollection();

            // Register services
            services.AddScoped<IAuthenticationService, AuthenticationService>();

            // Build service provider
            ServiceProvider = services.BuildServiceProvider();
        }
    }

}
