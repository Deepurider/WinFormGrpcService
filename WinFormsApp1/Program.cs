using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WinFormsApp1.Config;
using IConfiguration = WinFormsApp1.Config.IConfiguration;

namespace WinFormsApp1
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            var services = AddConfiguration(new ServiceCollection());
            OpenForm(services);
        }

        private static void OpenForm(IServiceCollection services)

        {
            ApplicationConfiguration.Initialize();
            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                var index = serviceProvider.GetRequiredService<Index>();
                Application.Run(index);
            }
        }

        private static IServiceCollection AddConfiguration(IServiceCollection serviceCollection)
        {
            var config = new ConfigurationBuilder().
                           SetBasePath(Directory.
                           GetCurrentDirectory()).
                           AddJsonFile("appsettings.json").Build();
            serviceCollection.AddSingleton<Index>();
            serviceCollection.AddScoped<HttpClient>();
            serviceCollection.Configure<Configuration>(config);
            serviceCollection.AddScoped<IConfiguration, Configuration>();
            return serviceCollection;
        }
    }
}