namespace Presentation.Dependency.Server.Services
{
    public interface IListingService
    {
        IEnumerable<string> Add(string data);
    }
}
