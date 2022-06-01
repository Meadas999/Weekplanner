using Microsoft.AspNetCore.Mvc;

namespace WebFront_End.Controllers
{
    public class VoedingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
