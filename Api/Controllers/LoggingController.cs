using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class LoggingController : Controller
    {
        private readonly ILogger<UserController> logger;

        public LoggingController(ILogger<UserController> logger)
        {
            this.logger = logger;
        }
        [HttpGet("")]
        public IActionResult Index()
        {
            logger.LogInformation("Processing request for home page...");
            return Content("OK");
        }
    }
}
