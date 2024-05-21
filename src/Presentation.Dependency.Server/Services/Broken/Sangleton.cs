namespace Presentation.Dependency.Server.Services.Broken
{
    public class Sangleton
    {
        public Sangleton(Soaped soapedService)
        {
            // Something more long lived shouldn't have reference to scoped things
        }
    }
}
