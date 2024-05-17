using Presentation.Dependency.Server.Services;
using Presentation.Dependency.Server.Services.Decorators;

namespace Presentation.Dependency.Server
{
    public static class Startup
    {
        public static IServiceCollection StandardRegistration(this IServiceCollection services) 
        {
            services.AddScoped<ScopedListingService>();
            services.AddTransient<TransientListingService>();
            services.AddSingleton<SingletonListingService>();
            services.AddTransient<CompoundListingService>();
            services.AddTransient<CompoundListing2Service>();

            services.AddSingleton<IDatabaseService, FakeDatabaseService>();
            services.AddScoped<IPaymentProviderRouter, PaymentServiceProviderRouterService>();
            services.AddScoped<IPaymentProvider, ScroogeMcduckBankPaymentProvider>();
            services.AddScoped<IPaymentProvider, PixelPayPaymentProvider>();
            return services;
        }

        public static IServiceCollection RegisterAllTheThings(this IServiceCollection services)
        {
            return services;
        }

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

            services.AddScoped<ScopedListingService>();
            services.AddTransient<TransientListingService>();
            services.AddSingleton<SingletonListingService>();
            services.AddTransient<CompoundListingService>();
            services.AddTransient<CompoundListing2Service>();


            return services;
        }
    }
}
