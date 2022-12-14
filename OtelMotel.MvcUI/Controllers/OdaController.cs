using Microsoft.AspNetCore.Mvc;

namespace OtelMotel.MvcUI.Controllers
{
    public class OdaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
