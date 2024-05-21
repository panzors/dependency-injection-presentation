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
            services.AddScoped<CompoundListingService>();
            services.AddScoped<CompoundListing2Service>();

            services.AddSingleton<IDatabaseService, FakeDatabaseService>();
            services.AddScoped<IPaymentProviderRouter, PaymentServiceProviderRouterService>();
            services.AddScoped<IPaymentProvider, ScroogeMcduckBankPaymentProvider>();
            services.AddScoped<IPaymentProvider, PixelPayPaymentProvider>();

            return services;
        }

        public static IServiceCollection RegisterOtherThings(this IServiceCollection services)
        {
            // Simple http client
            if (true)
            {
                services.AddHttpClient<IJokeClient, JokeClient>();
            } 
            else // longer way around
            {
                // Named client alternative
                services.AddScoped<IJokeClient, JokeClient2>();
                services.AddHttpClient("otherclient", (client) =>
                        client.BaseAddress = new Uri("https://v2.jokeapi.dev")
                    );
            }

            // register functions
            services.AddScoped<Func<IEnumerable<string>>>((_) =>
            {
                // Dynamically allocate if you so choose?
                // Service provider is provided in here if you have need of other registered settings
                return () => new[] { "Hello", "World" }.AsEnumerable();
            });

            services.AddScoped<IHelloWorldService, HelloWorldService>();

            return services;
        }

        public static IServiceCollection RegisterWithScrutor(this IServiceCollection services)
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

        public static IServiceCollection RegisterConcreteClasses(this IServiceCollection services)
        {
            // You can register concrete classes if you so choose. You don't have to register Interfaces
            // It can get messy though so be careful what you're trying to achieve
            services.AddScoped<ScopedListingService>();
            services.AddTransient<TransientListingService>();
            services.AddSingleton<SingletonListingService>();
            services.AddTransient<CompoundListingService>();
            services.AddTransient<CompoundListing2Service>();

            return services;
        }

        public static IServiceCollection BrokenRegistrations(this IServiceCollection services)
        {
            // Comment these in to see their damage

            // Presentation.Dependency.Server.Services.Broken.Sangleton Lifetime: Singleton ImplementationType: Presentation.Dependency.Server.Services.Broken.Sangleton': Cannot consume scoped service 
            //services.AddSingleton<Services.Broken.Sangleton>();
            
            services.AddScoped<Services.Broken.Soaped>();

            services.AddTransient<Services.Broken.Transistant>();

            return services;
        }
    }
}
