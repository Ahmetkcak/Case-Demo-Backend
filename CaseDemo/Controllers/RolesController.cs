using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CaseDemo.Controllers
{
    public class RolesController(RoleManager<IdentityRole> roleManager) : Controller
    {
        public IActionResult Index()
        {
            var roles= roleManager.Roles;
            return View(roles);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(IdentityRole role)
        {
            if(!roleManager.RoleExistsAsync(role.Name).GetAwaiter().GetResult())
            {
                roleManager.CreateAsync(new IdentityRole(role.Name)).GetAwaiter().GetResult();
            }
            return RedirectToAction("Index");
        }
    }
}
