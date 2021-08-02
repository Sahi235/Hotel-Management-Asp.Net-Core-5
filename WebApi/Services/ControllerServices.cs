using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.Services
{
    public static class ControllerServices
    {
        public static void AddControllerServices(this IServiceCollection service)
        {
            service.AddControllers();
        }
    }
}
