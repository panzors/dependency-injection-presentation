namespace Presentation.Dependency.Server.Services
{
    public interface IJokeClient
    {
        Task<JokeModel?> GetJokeAsync();
    }

    public class JokeClient: IJokeClient
    {
        private HttpClient _client;

        public JokeClient(HttpClient client)
        {
            _client = client;
            client.BaseAddress = new Uri("https://v2.jokeapi.dev");
        }

        public Task<JokeModel?> GetJokeAsync()
        {
            var message = new HttpRequestMessage(HttpMethod.Get, "joke/Programming?type=single");
            var response = _client.Send(message);
            response.EnsureSuccessStatusCode();

            return response.Content.ReadFromJsonAsync<JokeModel>();
        }
    }

    public class JokeClient2 : IJokeClient
    {
        private HttpClient _client;

        public JokeClient2(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("otherclient");
        }

        public Task<JokeModel?> GetJokeAsync()
        {
            var message = new HttpRequestMessage(HttpMethod.Get, "joke/Programming?type=single");
            var response = _client.Send(message);
            response.EnsureSuccessStatusCode();

            return response.Content.ReadFromJsonAsync<JokeModel>();
        }
    }

    public class JokeModel
    {
        public string Joke { get; set; }
    }
}
