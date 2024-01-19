using Microsoft.AspNetCore.Mvc;

namespace MVCIntroDemo.Controllers
{
    public class NumbersController : Controller
    {
        private readonly ILogger logger;

        public NumbersController(ILogger<NumbersController> _logger)
        {
            logger = _logger;
        }

        public IActionResult Index()
        {
            return View(50);
        }

        [HttpGet]
        public IActionResult Limit(int number)
        {
            return View("Index", number);
        }
    }
}
