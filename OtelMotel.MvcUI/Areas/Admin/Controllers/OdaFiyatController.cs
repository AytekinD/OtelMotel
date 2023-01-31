using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OtelMotel.BL.Abstract;
using OtelMotel.BL.Concrete;
using OtelMotel.Entities.Entities.Concrete;
using OtelMotel.MvcUI.Areas.Admin.Models.OdaFiyat;

namespace OtelMotel.MvcUI.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class OdaFiyatController : Controller
    {
        private readonly IOdaFiyatManager odaFiyatManager;
        private readonly IOdaManager odaManager;

        public OdaFiyatController(IOdaFiyatManager odaFiyatManager, IOdaManager odaManager)
        {
            this.odaFiyatManager = odaFiyatManager;
            this.odaManager = odaManager;
        }
        public async Task<IActionResult> Index()
        {
            var result = await odaFiyatManager.FindAllIncludeAsync(null, p => p.Oda);
            return View(result.ToList());
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {

            var createDto = new OdaFiyatCreateDTO();
            @ViewBag.Odalar = GetOdalar();
            return View(createDto);


        }

        [HttpPost]
        public async Task<IActionResult> Create(OdaFiyatCreateDTO createDTO)
        {
            if(!ModelState.IsValid)
            {
                @ViewBag.Roller = GetOdalar();
                return View(createDTO);
            }
            var odaFiyat = new OdaFiyat() 
            {
                Baslangic=createDTO.Baslangic,
                Bitis=createDTO.Bitis,
                Fiyat=createDTO.Fiyat,
                
            };

            var result = await odaFiyatManager.CreateAsync(odaFiyat);
            if (result > 0)
            {
                return RedirectToAction("Index", "OdaFiyat");
            }
            else
            {
                ModelState.AddModelError("", "Bilinmeyen bir hata olustu.");
                @ViewBag.Roller = GetOdalar();
                return View(createDTO);
            } 

        }


        [NonAction]
        private List<SelectListItem> GetOdalar()
        {
            var odalar = odaManager.FindAllAsync(null).Result;

            List<SelectListItem> ListItemRols = new();
            foreach (Oda oda in odalar)
            {
                ListItemRols.Add(new SelectListItem(oda.OdaNo, oda.Id.ToString()));
            }
            return ListItemRols;
        }
    }
}
