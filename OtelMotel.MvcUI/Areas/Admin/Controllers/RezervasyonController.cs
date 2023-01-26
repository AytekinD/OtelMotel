using Microsoft.AspNetCore.Mvc;
using OtelMotel.BL.Abstract;
using OtelMotel.MvcUI.Areas.Admin.Models.Rezervasyon;

namespace OtelMotel.MvcUI.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class RezervasyonController : Controller
    {
        private readonly IRezervasyonManager rezervasyonManager;
        private readonly IOdaManager odaManager;
        private readonly IOdaFiyatManager odaFiyatManager;

        public RezervasyonController(IRezervasyonManager rezervasyonManager, IOdaManager odaManager, IOdaFiyatManager odaFiyatManager)
        {
            this.rezervasyonManager = rezervasyonManager;
            this.odaManager = odaManager;
            this.odaFiyatManager = odaFiyatManager;
        }
        public async Task<IActionResult> Index()
        {
            var result = await rezervasyonManager.FindAllAsync();
            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var createDTO = new RezervasyonCreateDTO();
            @ViewBag.Odalar = GetOdalar();
            @ViewBag.Fiyatlar = GetOdaFiyatlari();
            return View(createDTO);
        }

        private dynamic GetOdaFiyatlari()
        {
            throw new NotImplementedException();
        }

        private dynamic GetOdalar()
        {
            throw new NotImplementedException();
        }
    }
}
