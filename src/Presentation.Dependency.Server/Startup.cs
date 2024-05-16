using Presentation.Dependency.Server.Services;

namespace Presentation.Dependency.Server
{
    public static class Startup
    {
        public static IServiceCollection AddServices(this IServiceCollection services) 
        {
            services.AddScoped<IScopedService, ScopedService>();
            services.AddTransient<ITransientService, TransientService>();
            services.AddSingleton<ISingletonService, SeasonsService>();
            return services;
        }

        public static IServiceCollection AddServices2(this IServiceCollection services)
        {
            //services.AddScoped<Func<IEnumerable>>
            return services;
        }
    }
}
