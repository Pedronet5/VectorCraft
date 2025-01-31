﻿namespace VectorCalculatorApp
{
    using Microsoft.Extensions.DependencyInjection;
    using System.Windows;
    using ViewModel;
    using VectorCraft;
    using VectorCalculatorApp.Views;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IServiceProvider serviceProvider;
 
        public App()
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();
        }
 
        private void ConfigureServices(ServiceCollection services)
        {
            services.AddTransient<IVector3D, Vector3D>();
            services.AddSingleton(s => new VectorViewModel(s.GetRequiredService<IVector3D>()));
            services.AddSingleton(s => new MainWindow()
            {
                DataContext = s.GetRequiredService<VectorViewModel>()
            });
        }
 
        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = serviceProvider.GetService<MainWindow>();
            
            if (mainWindow != null)
            {
                mainWindow.Show();
            }
        }
    }
}
