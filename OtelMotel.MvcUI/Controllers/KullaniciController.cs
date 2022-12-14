using Microsoft.AspNetCore.Mvc;
using OtelMotel.BL.Abstract;

namespace OtelMotel.MvcUI.Controllers
{
    public class KullaniciController : Controller
    {
        private readonly IKullaniciManager kullaniciManager;

        public KullaniciController(IKullaniciManager kullaniciManager)
        {
            this.kullaniciManager = kullaniciManager;
        }
        public async Task<IActionResult> Index()
        {
            var result = await kullaniciManager.FindAllAsync();
            return View(result);
        }
        public async Task<IActionResult> Kayit()
        {
            return View();
        }
    }
}
