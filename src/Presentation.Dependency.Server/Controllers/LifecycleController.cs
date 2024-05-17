using Microsoft.AspNetCore.Mvc;
using Presentation.Dependency.Server.Services;

namespace Presentation.Dependency.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LifecycleController
    {
        public LifecycleController() { }

        [HttpPost]
        [Route("singleton/{input}")]
        public IEnumerable<string> AddSingleton(
            [FromServices] SingletonListingService service,
            [FromRoute] string input)
        {
            return service.Add(input);
        }

        [HttpPost]
        [Route("transient/{input}")]
        public IEnumerable<string> AddTransient(
            [FromServices] TransientListingService service,
            [FromRoute] string input)
        {
            return service.Add(input);
        }

        [HttpPost]
        [Route("scoped/{input}")]
        public IEnumerable<string> AddScoped(
            [FromServices] ScopedListingService service,
            [FromRoute] string input)
        {
            return service.Add(input);
        }

        [HttpPost]
        [Route("compound/{input}")]
        public IEnumerable<string> AddCompound(
            [FromServices] CompoundListingService service,
            [FromServices] CompoundListing2Service service2,
            [FromRoute] string input)
        {
            var result = new List<string>();
            result.AddRange(service.Add("1:" + input));
            result.AddRange(service2.Add("2:" + input));
            return result;
        }
    }
}
