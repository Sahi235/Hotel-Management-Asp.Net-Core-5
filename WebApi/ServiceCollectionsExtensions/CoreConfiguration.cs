using Microsoft.Extensions.DependencyInjection;

namespace WebApi.ServiceCollectionsExtensions
{
    public static class CoreConfiguration
    {
        public static void AddNewCorsPolicy(this IServiceCollection service)
        {
            service.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                {
                    builder.AllowAnyHeader();
                    builder.AllowAnyOrigin();
                    builder.AllowAnyHeader();
                });
            });
        }
    }
}
