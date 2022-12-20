using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OtelMotel.BL.Abstract;
using OtelMotel.Entities.Entities.Concrete;
using OtelMotel.MvcUI.Areas.Admin.Models.Kullanici;

namespace OtelMotel.MvcUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class KullaniciController : Controller
    {

        private readonly IKullaniciManager kullaniciManager;
        private readonly IRoleManager roleManager;

        public KullaniciController(IKullaniciManager kullaniciManager, IRoleManager roleManager)
        {
            this.kullaniciManager = kullaniciManager;
            this.roleManager = roleManager;
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
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Uploads", randomName);
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
            kullanici.TcNo = updateDTO.TcNo;
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
        [HttpGet]
        public async Task<IActionResult> Create()
        {

            var createDto = new KullaniciCreateDTO();
            @ViewBag.Roller = GetRoller();

            return View(createDto);
        }
        [HttpPost]
        public async Task<IActionResult> Create(KullaniciCreateDTO createDTO)
        {
            if (!ModelState.IsValid)
            {
                @ViewBag.Roller = GetRoller();
                return View(createDTO);
            }

            var kullanici = new Kullanici()
            {
                Adi = createDTO.Adi,
                Soyadi = createDTO.Soyadi,
                Cinsiyet = true,
                DogumTarihi = createDTO.DogumTarihi,
                Email = createDTO.Email,
                TcNo = createDTO.TcNo,

            };

            if (createDTO.ImageFile != null)
            {
                var extent = Path.GetExtension(createDTO.ImageFile.FileName);
                var randomName = ($"{Guid.NewGuid()}{extent}");
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Uploads", randomName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await createDTO.ImageFile.CopyToAsync(stream);
                }
                using (MemoryStream ms = new MemoryStream())
                {
                    createDTO.ImageFile.CopyTo(ms);
                    kullanici.ImageData = ms.ToArray();
                }
            }
            var sonuc = await kullaniciManager.CreateAsync(kullanici);
            if (sonuc > 0)
            {
                return RedirectToAction("Index", "Kullanici");
            }
            else
            {
                ModelState.AddModelError("", "Bilinmeyen bir hata olustu.Deaha sonra tekra deneyibiz");
                @ViewBag.Roller = GetRoller();
                return View(kullanici);
            }


        }
        [NonAction]
        private List<SelectListItem> GetRoller()
        {
            var roller = roleManager.FindAllAsync(null).Result;

            List<SelectListItem> ListItemRols = new();
            foreach (Role role in roller)
            {
                ListItemRols.Add(new SelectListItem(role.RoleName, role.Id.ToString()));
            }
            return ListItemRols;
        }
    }
}
