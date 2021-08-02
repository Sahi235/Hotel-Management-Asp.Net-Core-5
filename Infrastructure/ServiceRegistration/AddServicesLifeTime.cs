using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure.BaseRepositories;
using Infrastructure.RoomTypes.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.ServiceRegistration
{
    public static class AddServicesLifeTime
    {
        public static IServiceCollection AddDomainHandlers(this IServiceCollection service)
        {
            service.AddScoped<IRoomTypesRepository, RoomTypesRepository>();
            return service;
        }
    }
}
