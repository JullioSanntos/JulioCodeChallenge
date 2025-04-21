using System.Configuration;
using System.Data;
using System.Windows;
using JulioCode01.Views;
using JulioCode06.ViewModels;
using JulioCode12.Common;
using Microsoft.Extensions.DependencyInjection;

namespace JulioCode01.Views {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {
        public Configuration Configuration { get; set; }



        public App() {
            var serviceCollection = new ServiceCollection();
            serviceCollection.ConfigureServices();
            ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            var viewModel = serviceProvider.GetRequiredService<LoadTradesService>();
            var mainWindow = serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        
    }

}

public static class ServiceCollectionExtensions {

    public static void ConfigureServices(this IServiceCollection services) {
        services.AddSingleton<LoadTradesService>();
        services.AddSingleton<MainViewModel>();
        services.AddSingleton<MainWindow>();
    }

}
