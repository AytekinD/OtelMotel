using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OtelMotel.BL.Abstract;
using OtelMotel.Entities.Entities.Concrete;

namespace OtelMotel.MvcUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        private readonly IRoleManager roleMAnager;

        public RoleController(IRoleManager roleMAnager)
        {
            this.roleMAnager = roleMAnager;
        }
        public async Task<IActionResult> Index()
        {
            var result = await roleMAnager.FindAllAsync();
            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var roleCreate = new Role();
            return View(roleCreate);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Role role)
        {
            if (!ModelState.IsValid)
            {
                return View(role);
            }

            var roleCreate = new Role() 
            {
                KullaniciId= role.KullaniciId,
                RoleName= role.RoleName,
                Status= role.Status
            };

            var sonuc = await roleMAnager.CreateAsync(role);

            if (sonuc > 0)
            {
                return RedirectToAction("Index", "Role");
            }
            else
            {
                ModelState.AddModelError("", "Bilinmeyen bir hata olustu."); 
                return View(role);
            }

        }


    }
}
