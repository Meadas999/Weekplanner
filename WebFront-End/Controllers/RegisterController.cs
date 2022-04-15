using Microsoft.AspNetCore.Mvc;

namespace WebFront_End.Controllers
{
    public class RegisterController : Controller
    {
        private readonly ILogger<LogInController> _logger;
        public RegisterController(ILogger<LogInController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
