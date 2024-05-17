namespace Presentation.Dependency.Server.Services
{
    public interface IHelloWorldService 
    {
        string Speak();
    }
    public class HelloWorldService : IHelloWorldService
    {
        private Func<IEnumerable<string>> _generator;

        public HelloWorldService(Func<IEnumerable<string>> generator) 
        {
            _generator = generator;
        }

        public string Speak()
        {
            return String.Join(" ", _generator());
        }
    }
}
