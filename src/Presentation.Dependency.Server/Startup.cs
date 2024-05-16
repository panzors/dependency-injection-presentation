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

        public static IServiceCollection RegisterDifferentThings(this IServiceCollection services)
        {
            services.Scan(scan => scan.FromAssemblyOf<ITransientService>()
                .AddClasses(classes => classes.AssignableTo<ITransientService>())
                    .AsImplementedInterfaces()
                    .WithTransientLifetime()
                .AddClasses(classes => classes.AssignableTo<IScopedService>())
                    .AsImplementedInterfaces()
                    .WithScopedLifetime()
                .AddClasses(classes => classes.AssignableTo<ISingletonService>())
                    .AsImplementedInterfaces()
                    .WithSingletonLifetime()
                );

            services.Decorate<IPaymentProvider, TelemetricsDecorator>();

            return services;
        }
    }
}
