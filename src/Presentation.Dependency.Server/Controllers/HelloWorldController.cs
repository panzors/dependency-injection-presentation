using Microsoft.AspNetCore.Mvc;
using Presentation.Dependency.Server.Services;

namespace Presentation.Dependency.Server.Controllers
{
    [Route("[controller]")]
    public class HelloWorldController
    {
        [HttpGet]
        [Route("speak")]
        public string Speak([FromServices] IHelloWorldService helloWorldService)
        {
            return helloWorldService.Speak();
        }
    }
}
