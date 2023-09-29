using Cleaner.Application;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;

namespace Cleaner.Hosting.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PathController : ControllerBase
    {
        private readonly ILogger<PathController> logger;
        private readonly IPathRequestHandler requestHandler;

        public PathController(ILogger<PathController> logger, IPathRequestHandler requestHandler)
        {
            this.logger = logger;
            this.requestHandler = requestHandler;
        }

        [HttpPost]
        [SwaggerRequestExample(typeof(CleanRequest), typeof(PathExamples))]
        public async Task<ActionResult<CleanResult>> EnterPath([FromBody] CleanRequest request)
        {
            logger.LogInformation($"Received request:");
            logger.LogInformation($"{request.Start}, {string.Join(", ", request.Commands.Select(x => $"{x.direction} - {x.steps}"))}");

            var result = await requestHandler.HandleRequest(request);
            return CreatedAtAction(nameof(EnterPath), result);
        }

    }
}