using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OtelMotel.BL.Abstract;
using OtelMotel.MvcUI.Areas.Admin.Models.Kullanici;

namespace OtelMotel.MvcUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class KullaniciController : Controller
    {
        private readonly IKullaniciManager kullaniciManager;

        public KullaniciController(IKullaniciManager kullaniciManager)
        {
            this.kullaniciManager = kullaniciManager;
        }
        public async Task<IActionResult> Index()
        {
            var result = await kullaniciManager.FindAllIncludeAsync(null, p => p.Roller);
            return View(result.ToList());
        }
        public async Task<IActionResult> Kayit()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid Id)
        {
            var kullanici = kullaniciManager.FindAsync(p => p.Id == Id).Result;
            KullaniciDTO updateDto = new KullaniciDTO
            {
                Id = kullanici.Id,
                Adi = kullanici.Adi,
                Soyadi = kullanici.Soyadi,
                Email = kullanici.Email,
                Password = kullanici.Password,
                RePassword = kullanici.Password,
                DogumTarihi = kullanici.DogumTarihi,
                TcNo = kullanici.TcNo,
                Cinsiyet = kullanici.Cinsiyet,
                KullaniciAdi = kullanici.KullaniciAdi,

            };
            return View(updateDto);
        }
        [HttpPost]
        public async Task<IActionResult> Update(KullaniciDTO updateDTO)
        {
            if (!ModelState.IsValid)
            {
                return View(updateDTO);
            }
            var kullanici = kullaniciManager.FindAsync(p => p.Id == updateDTO.Id).Result;

            if (updateDTO.ImageFile != null)
            {
                var extent = Path.GetExtension(updateDTO.ImageFile.FileName);
                var randomName = ($"{Guid.NewGuid()}{extent}");
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwroot\\Uploads", randomName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await updateDTO.ImageFile.CopyToAsync(stream);
                }
                using (MemoryStream ms = new MemoryStream())
                {
                    updateDTO.ImageFile.CopyTo(ms);
                    kullanici.ImageData = ms.ToArray();
                }
            }


            kullanici.Adi = updateDTO.Adi;
            kullanici.Soyadi = updateDTO.Soyadi;

            kullanici.DogumTarihi = updateDTO.DogumTarihi;
            kullanici.Password = updateDTO.Password;
            kullanici.Update = DateTime.Now;

            var sonuc = await kullaniciManager.UpdateAsync(kullanici);
            if (sonuc > 0)
            {
                return RedirectToAction("Index", "Kullanici");
            }
            else
            {
                ModelState.AddModelError("", "Bilinmeyen bir hata olustu.Tekrar deneyiniz.");
                return View(updateDTO);
            }
        }
    }
}
