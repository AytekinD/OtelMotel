using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OtelMotel.BL.Concrete;

namespace OtelMotel.MvcUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class MusteriController : Controller
    {
        private readonly MusteriManager musteriManager;

        public MusteriController(MusteriManager musteriManager)
        {
            this.musteriManager = musteriManager;
        }
        public async Task<IActionResult> Index()
        {
            var result = await musteriManager.FindAllAsync(null);
            return View(result.ToList());
        }
        //[HttpGet]
        //public async Task<IActionResult> Create()
        //{

        //    var createDto = new MusteriCreateDTO();

        //    return View(createDto);
        //}
        //[HttpPost]
        //public async Task<IActionResult> Create(MusteriCreateDTO createDTO)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(createDTO);
        //    }

        //    var musteri = new Musteri()
        //    {
        //        Ad = createDTO.Ad,
        //        Soyad = createDTO.Soyad,
        //        MusteriTcNo = createDTO.MusteriTcNo,
        //        CepNo = createDTO.CepNo,
        //    };


        //    var sonuc = musteriManager.CreateAsync(musteri);
        //    if (sonuc > 0)
        //    {
        //        return RedirectToAction("Index", "Musteri");
        //    }
        //    else
        //    {
        //        ModelState.AddModelError("", "Bilinmeyen bir hata olustu.Deaha sonra tekra deneyibiz"); return View(musteri);
        //    }
        //}
    }
}
