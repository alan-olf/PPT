using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using PPT.App.Common.Dependency;
using PPT.App.Core.Data;
using Microsoft.EntityFrameworkCore;
using PPT.App.Core.Data.Store;

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

            services.AddDbContext<DataContext>(options =>
            {
                var BaseDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                options.UseSqlite(configuration.GetConnectionString("DefaultConnectionString").Replace("{BASE}", BaseDirectory), builder => { builder.CommandTimeout(120); });

            });
            services.AddScoped(typeof(IStore<>), typeof(Store<>));

            return services;
        }

    }

}
