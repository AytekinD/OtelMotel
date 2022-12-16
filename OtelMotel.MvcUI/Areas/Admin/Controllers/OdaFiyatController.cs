using Microsoft.AspNetCore.Mvc;

namespace OtelMotel.MvcUI.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class OdaFiyatController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
