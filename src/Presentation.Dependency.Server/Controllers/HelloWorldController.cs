using Microsoft.AspNetCore.Mvc;
using Presentation.Dependency.Server.Services;
using Presentation.Dependency.Server.Services.Broken;

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

        //[HttpGet]
        //[Route("alternative")]
        //public string Alternative([FromServices] Sangleton sangleton)
        //{
        //    return "sangleton loaded";
        //}
    }
}
