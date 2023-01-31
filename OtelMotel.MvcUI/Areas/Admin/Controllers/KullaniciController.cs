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
                DogumTarihi = (DateTime)kullanici.DogumTarihi,
                TcNo = kullanici.TcNo,
                Cinsiyet = (bool)kullanici.Cinsiyet,
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
            //Eger IFromFile Tipindeki prop bos degilse serverda upload klasorune kopyala
            // Ve Database'de ImageData alanina yazdir.
            var kullanici = kullaniciManager.FindAsync(p => p.Id == updateDTO.Id).Result;

            if (updateDTO.ImageFile != null)
            {
                var extent = Path.GetExtension(updateDTO.ImageFile.FileName);
                var randomName = ($"{Guid.NewGuid()}{extent}");
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Uploads", randomName);
                kullanici.ImageUrl = "Uploads\\" + randomName;
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
            //UpdateDto Kullanici Tipine cevirmek gerekiyor

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
                KullaniciAdi = createDTO.KullaniciAdi,
                Password = createDTO.Password,
            };

            #region Eger role atanmis ise

            //if (createDTO.Roller.Count > 0)
            //{
            //    foreach (var roleId in createDTO.Roller)
            //    {
            //        var role = await roleManager.GetByIdAsync(roleId);

            //        kullanici.Roller.Add(role);

            //    }
            //} 
            #endregion
            #region Eger Image Seciliyse

            if (createDTO.ImageFile != null)
            {
                var extent = Path.GetExtension(createDTO.ImageFile.FileName);
                var randomName = ($"{Guid.NewGuid()}{extent}");
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Uploads", randomName);
                kullanici.ImageUrl = "Uploads\\" + randomName;
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await createDTO.ImageFile.CopyToAsync(stream);
                }

                using (MemoryStream ms = new MemoryStream())
                {
                    //postedFile.CopyTo(ms);	
                    createDTO.ImageFile.CopyTo(ms);
                    kullanici.ImageData = ms.ToArray();
                }
            }
            #endregion


            var sonuc = await kullaniciManager.CreateAsync(kullanici);

            foreach (var item in createDTO.Roller)
            {


            }


            if (sonuc > 0)
            {
                return RedirectToAction("Index", "Kullanici");
            }
            else
            {
                ModelState.AddModelError("", "Bilinmeyen bir hata olustu. Daha Sonra Tekrar Deneyiniz");
                @ViewBag.Roller = GetRoller();
                return View(createDTO);
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
