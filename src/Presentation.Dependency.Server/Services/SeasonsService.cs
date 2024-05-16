namespace Presentation.Dependency.Server.Services
{
    public interface ISeasonsService
    {
        string NextSeason();
    }

    public class SeasonsService: ISeasonsService, ISingletonService
    {
        private int _counter = 0;
        public static string[] AllSeasons = { "Summer", "Autum", "Winter", "Spring" };

        public string NextSeason()
        {
            var result = AllSeasons[_counter];
            _counter = (_counter + 1) % AllSeasons.Length;
            return result;
        }
    }
}
