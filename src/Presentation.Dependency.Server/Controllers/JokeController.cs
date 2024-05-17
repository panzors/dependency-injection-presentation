using Microsoft.AspNetCore.Mvc;
using Presentation.Dependency.Server.Services;

namespace Presentation.Dependency.Server.Controllers
{
    [Route("[controller]")]
    public class JokeController
    {
        [HttpGet]
        public async Task<string> GetJoke([FromServices] IJokeClient jokeClient) 
        {
            var response = await jokeClient.GetJokeAsync();

            return response?.Joke ?? "No joke is too funny";
        }


    }
}
