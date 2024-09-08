using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebProjeOdev.Controllers
{
    [Authorize(Roles = "ADMIN")]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "USER,ADMIN")]
        public IActionResult ManageUsers()
        {
            // Kullanıcı yönetimi için gerekli verileri burada hazırlayıp gönderebilirsiniz.
            return View();
        }
        [Authorize(Roles = "ADMIN")]
        public IActionResult Guncelleme()
        {
            // Kullanıcı yönetimi için gerekli verileri burada hazırlayıp gönderebilirsiniz.
            return View();
        }
    }
}
