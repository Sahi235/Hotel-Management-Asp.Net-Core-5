using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            //var hostBuilder = CreateHostBuilder(args).Build();
            //using var scope = hostBuilder.Services.CreateScope();
            //var services = scope.ServiceProvider;
            //try
            //{
            //    var context = services.GetRequiredService<DatabaseContext>();
            //    var initialize = services.GetRequiredService<IInitialize>();

            //    DbInitialize.Initialize(context, initialize).Wait();
            //}
            //catch (Exception e)
            //{
            //    var logger = services.GetRequiredService<ILogger<Program>>();
            //    logger.LogError(e, "Something went wrong");
            //}
            //hostBuilder.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
