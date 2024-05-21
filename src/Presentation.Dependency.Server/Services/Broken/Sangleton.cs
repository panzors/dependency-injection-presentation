namespace Presentation.Dependency.Server.Services.Broken
{
    public class Sangleton
    {
        public Sangleton(Soaped soapedService)
        {
            // Broken
        }

        public Sangleton(Transistant transistant)
        {
            // Also broken
        }

        // Instead you can use this style if you want to work in a scope
        // public Sangleton(IServiceProvider provider)
        // {
        //     var scope = provider.CreateScope();
        //     var soaped = scope.ServiceProvider.GetService<Soaped>();
        // }
    }
}
