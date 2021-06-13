using FlockITChallenge.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlockITChallenge.Core
{
    public static class IoC
    {
        public static IServiceCollection AddDependencyAuthService(this IServiceCollection services)
        {
            services.AddTransient<IAuthService, AuthService>();
            return services;
        }
        public static IServiceCollection AddDependencyGeoRefService(this IServiceCollection services)
        {
            services.AddTransient<IGeoRefService, GeoRefService>();
            return services;
        }
    }
}
