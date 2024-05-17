namespace Presentation.Dependency.Server.Services
{
    public class TransientListingService : IListingService, ITransientService
    {
        private readonly List<string> _data;

        public TransientListingService()
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
