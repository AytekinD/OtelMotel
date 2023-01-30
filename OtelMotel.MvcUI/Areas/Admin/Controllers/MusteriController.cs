using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OtelMotel.BL.Abstract;
using OtelMotel.Entities.Entities.Concrete;
using OtelMotel.MvcUI.Areas.Admin.Models.Musteri;
using System.Security.Claims;

namespace OtelMotel.MvcUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class MusteriController : Controller
    {
        private readonly IMusteriManager musteriManager;

        public MusteriController(IMusteriManager musteriManager)
        {
            this.musteriManager = musteriManager;
        }
        public async Task<IActionResult> Index()
        {
            var result = await musteriManager.FindAllAsync(null);
            return View(result.ToList());
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {

            var createDto = new MusteriCreateDTO();

            return View(createDto);
        }


        [HttpPost]
        public async Task<IActionResult> Create(MusteriCreateDTO createDTO)
        {
            if (!ModelState.IsValid)
            {
                return View(createDTO);
            }

            var musteri = new Musteri()
            {
                Ad = createDTO.Ad,
                Soyad = createDTO.Soyad,
                MusteriTcNo = createDTO.MusteriTcNo,
                CepNo = createDTO.CepNo,
                Cinsiyet = createDTO.Cinsiyet,
                KullaniciId = Guid.Parse(User.Claims.FirstOrDefault(p => p.Type == ClaimTypes.NameIdentifier).Value)
            };


            var sonuc = await musteriManager.CreateAsync(musteri);
            if (sonuc > 0)
            {
                return RedirectToAction("Index", "Musteri");
            }
            else
            {
                ModelState.AddModelError("", "Bilinmeyen bir hata olustu.Deaha sonra tekra deneyibiz"); return View(musteri);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid Id)
        {
            var musteri = await musteriManager.FindAsync(p => p.Id == Id);
            MusteriUpdateDTO updateDto = new MusteriUpdateDTO
            {
                Id = musteri.Id,
                Ad = musteri.Ad,
                Soyad = musteri.Soyad,
                MusteriTcNo = musteri.MusteriTcNo,
                CepNo = musteri.CepNo,
                Cinsiyet = musteri.Cinsiyet,
            };
            return View(updateDto);
        }

       
        [HttpPost]
        public async Task<IActionResult> Update(MusteriUpdateDTO updateDTO)
        {
            if (!ModelState.IsValid)
            {
                return View(updateDTO);
            }
            var musteri = musteriManager.FindAsync(p => p.Id == updateDTO.Id).Result;

            musteri.Ad = updateDTO.Ad;
            musteri.Soyad = updateDTO.Soyad;
            musteri.MusteriTcNo = updateDTO.MusteriTcNo;
            musteri.CepNo = updateDTO.CepNo;
            musteri.Cinsiyet = updateDTO.Cinsiyet;
            //musteri.KullaniciId = updateDTO.KullaniciId;

            var sonuc = await musteriManager.UpdateAsync(musteri);
            if (sonuc > 0)
            {
                return RedirectToAction("Index", "Musteri");
            }
            else
            {
                ModelState.AddModelError("", "Bilinmeyen bir hata olustu.Tekrar deneyiniz.");
                return View(updateDTO);
            }
        }

        [HttpDelete("{Id:Guid}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var musteri = await musteriManager.FindAsync(p => p.Id == Id);
            await musteriManager.DeleteAsync(musteri);

            return RedirectToAction("Index", "Musteri");

        }
        //[HttpPost]
        //public async Task<IActionResult> Delete(MusteriUpdateDTO updateDTO)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(updateDTO);
        //    }
        //    var musteri = musteriManager.FindAsync(p => p.Id == updateDTO.Id).Result;

        //    musteri.Ad = updateDTO.Ad;
        //    musteri.Soyad = updateDTO.Soyad;
        //    musteri.MusteriTcNo = updateDTO.MusteriTcNo;
        //    musteri.CepNo = updateDTO.CepNo;
        //    musteri.Cinsiyet = updateDTO.Cinsiyet;


        //    var sonuc = await musteriManager.DeleteAsync(musteri);
        //    if (sonuc > 0)
        //    {
        //    }
        //    else
        //    {
        //        ModelState.AddModelError("", "Bilinmeyen bir hata olustu.Tekrar deneyiniz.");
        //        return View(updateDTO);
        //    }
        //}
    }
}
