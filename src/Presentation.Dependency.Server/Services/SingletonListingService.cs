namespace Presentation.Dependency.Server.Services
{

    public class SingletonListingService: IListingService, ISingletonService
    {
        private readonly List<string> _data;

        public SingletonListingService()
        {
            _data = new List<string>();
        }

        public IEnumerable<string> Add(string data)
        {
            _data.Add(data);
            return _data;
        }
    }
}
