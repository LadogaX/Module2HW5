using Microsoft.Extensions.DependencyInjection;
using Modul2HW1;
using Modul2HW5;
using Module2HW5.Services;
using Module2HW5.Services.Abstractions;

namespace Module2HW5
{
   public class Program
    {
       public static void Main()
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<ILogger, Logger>()
                .AddTransient<IFileService, FileService>()
                .AddTransient<IConfigService, ConfigService>()
                .AddTransient<Starter>()
                .BuildServiceProvider();

            var starter = serviceProvider.GetService<Starter>();
            try
            {
                starter.Run();
            }
            finally
            {
                starter.Logger.Close();
            }
        }
    }
}
