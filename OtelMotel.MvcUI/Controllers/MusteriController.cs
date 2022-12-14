using Microsoft.AspNetCore.Mvc;

namespace OtelMotel.MvcUI.Controllers
{
    public class MusteriController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
