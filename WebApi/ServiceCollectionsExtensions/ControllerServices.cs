using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;

namespace WebApi.ServiceCollectionsExtensions
{
    public static class ControllerServices
    {
        public static void AddControllerServices(this IServiceCollection service)
        {
            service.AddControllers(options =>
            {
                options.RespectBrowserAcceptHeader = true;
                options.ReturnHttpNotAcceptable = true;
            }).AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            }).AddXmlDataContractSerializerFormatters();
        }
    }
}
