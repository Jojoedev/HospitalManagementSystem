using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this._roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var list = _roleManager.Roles.ToList();
            return View(list);
        }
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(IdentityRole identityRole)
        {
            await _roleManager.CreateAsync(identityRole);
            return RedirectToAction("Index");
        }
    }
}
