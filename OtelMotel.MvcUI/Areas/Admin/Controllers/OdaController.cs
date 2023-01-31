using Microsoft.AspNetCore.Mvc;
using OtelMotel.BL.Abstract;
using OtelMotel.BL.Concrete;
using OtelMotel.Entities.Entities.Abstract;
using OtelMotel.Entities.Entities.Concrete;
using OtelMotel.MvcUI.Areas.Admin.Models.Oda;
using System.Security.Claims;

namespace OtelMotel.MvcUI.Areas.Admin.Controllers
{
	[Area("Admin")]

	public class OdaController : Controller
	{
		private readonly IOdaManager odaManager;

		public OdaController(IOdaManager odaManager)
		{
			this.odaManager = odaManager;
		}
		public async Task<IActionResult> Index()
		{
			var result = await odaManager.FindAllAsync(p => p.Status == Status.Active || p.Status == Status.Update);
			return View(result);
		}
		[HttpGet]
		public async Task<IActionResult> Create()
		{

			var createDto = new OdaCreateDTO();

			return View(createDto);
		}
		[HttpPost]
		public async Task<IActionResult> Create(OdaCreateDTO createDTO)
		{
			if (!ModelState.IsValid)
			{
				return View(createDTO);
			}

			var oda = new Oda()
			{
				
				OdaNo = createDTO.OdaNo,
				KisiSayisi = createDTO.KisiSayisi,
				Durum = createDTO.Durum,
				KullaniciId = Guid.Parse(User.Claims.FirstOrDefault(p => p.Type == ClaimTypes.NameIdentifier).Value)

            };


			var sonuc = await odaManager.CreateAsync(oda);
			if (sonuc > 0)
			{
				return RedirectToAction("Index", "Oda");
			}
			else
			{
				ModelState.AddModelError("", "Bilinmeyen bir hata olustu.Deaha sonra tekra deneyibiz"); return View(oda);
			}
		}
		[HttpGet]
		public async Task<IActionResult> Update(Guid id)
		{
			var oda = await odaManager.FindAsync(p => p.Id == id);
			OdaUpdateDTO updateDto = new OdaUpdateDTO
			{
				OdaNo = oda.OdaNo,
				Durum = oda.Durum,
				KisiSayisi = oda.KisiSayisi
			};
			return View(updateDto);
		}
		[HttpPost]
		public async Task<IActionResult> Update(OdaUpdateDTO odaUpdateDTO)
		{
			if (!ModelState.IsValid)
			{
				return View(odaUpdateDTO);
			}
			var oda = await odaManager.FindAsync(p => p.Id == odaUpdateDTO.Id);
			oda.OdaNo = odaUpdateDTO.OdaNo;
			oda.Durum = odaUpdateDTO.Durum;
			oda.KisiSayisi = odaUpdateDTO.KisiSayisi;

			var sonuc = await odaManager.UpdateAsync(oda);
			if (sonuc > 0)
			{
				return RedirectToAction("Index", "Oda");
			}
			else
			{
				ModelState.AddModelError("", "Bilinmeyen bir hata olustu.Tekrar deneyiniz.");
				return View(odaUpdateDTO);
			}
		}

        [HttpGet]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var oda = await odaManager.FindAsync(p => p.Id == Id);
            return View(oda);

        }
        [HttpPost]
        public async Task<IActionResult> Delete(Oda oda)
		{
            var odadelete = await odaManager.FindAsync(p => p.Id == oda.Id);
            odaManager.DeleteAsync(odadelete);

            return RedirectToAction("Index", "Oda");
        }
    }
}
