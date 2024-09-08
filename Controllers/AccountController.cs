using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebProjeOdev.Models;

namespace WebProjeOdev.Controllers
{
    public class AccountController : Controller
    {

        private DataContext context;
        public AccountController(DataContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Kullanici entity)
        {
            context.Kullanicis.Add(entity);
            context.SaveChanges();
            var userRole = context.Rolles.Find("USER");
            if (userRole == null)
            {
                context.Rolles.Add(new Role() { Code = "USER", Description = "Kullanıcı" });
            }
            context.KullaniciRoles.Add(new KullaniciRole() { KullaniciID = entity.KullaniciID, Code = "USER" });
            context.SaveChanges();
            return View("KayitMesaji", entity);
        }
    }
}
