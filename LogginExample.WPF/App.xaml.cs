using LoggingExample.Core;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace LogginExample.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;


        public App()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            _serviceProvider= services.BuildServiceProvider();

      

        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ILoggerEngine, TextFileLogger>();
            services.AddSingleton<MainWindow>();
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = _serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }
}
