using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using SleeveArrow.IOC;
using SleeveArrow.Logger;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SleeveArrow
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IServiceProvider _serviceProvider;

        public App()
        {
            var host = Host.CreateDefaultBuilder()
                .UseAutofac()
                .UseSerilog()
                .Build();

            _serviceProvider = host.Services;

            host.StartAsync();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var main = _serviceProvider.GetRequiredService<MainWindow>();
            main.Show();

            base.OnStartup(e);
        }
    }
}