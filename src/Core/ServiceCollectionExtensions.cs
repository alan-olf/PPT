using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using PPT.App.Common.Dependency;

namespace PPT.App.Core
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCoreDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.Scan(scan =>
               scan.FromAssemblyOf<AppConstant>()
                   .AddClasses(classes => classes.AssignableTo<IScopeDependency>())
                   .AsImplementedInterfaces()
                   .WithScopedLifetime());
            
       
            return services;
        }

    }

}
