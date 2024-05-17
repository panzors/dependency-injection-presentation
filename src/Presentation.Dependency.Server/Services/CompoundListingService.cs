
namespace Presentation.Dependency.Server.Services
{
    public class CompoundListingService : IListingService, ITransientService
    {
        private readonly SingletonListingService _singleton;
        private readonly ScopedListingService _scoped;
        private readonly TransientListingService _transient;

        public CompoundListingService(SingletonListingService singleton, ScopedListingService scoped, TransientListingService transient) 
        {
            _singleton = singleton;
            _scoped = scoped;
            _transient = transient;
        }

        public IEnumerable<string> Add(string data)
        {
            var a = _singleton.Add("Singleton:" + data);
            var b = _scoped.Add("Scoped:" + data);
            var c = _transient.Add("Transient:" + data);

            return a.Union(b).Union(c);
        }
    }

    public class CompoundListing2Service : IListingService, ITransientService
    {
        private readonly SingletonListingService _singleton;
        private readonly ScopedListingService _scoped;
        private readonly TransientListingService _transient;

        public CompoundListing2Service(SingletonListingService singleton, ScopedListingService scoped, TransientListingService transient)
        {
            _singleton = singleton;
            _scoped = scoped;
            _transient = transient;
        }

        public IEnumerable<string> Add(string data)
        {
            var result = new List<string>();
            result.AddRange(_singleton.Add("Singleton:" + data));
            result.AddRange(_scoped.Add("Scoped:" + data));
            result.AddRange(_transient.Add("Transient:" + data));

            return result;
        }
    }
}
