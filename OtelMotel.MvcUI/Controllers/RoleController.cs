using Microsoft.AspNetCore.Mvc;
using OtelMotel.BL.Abstract;

namespace OtelMotel.MvcUI.Controllers
{
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
    }
}
