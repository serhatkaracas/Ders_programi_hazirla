using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using WebProjeOdev.Models;
using Microsoft.EntityFrameworkCore;

public class AccessController : Controller
{
    private readonly DataContext _context;

    public AccessController(DataContext context)
    {
        _context = context;
    }

    // Giriş sayfasını yüklemek için GET metodu
    [HttpGet]
    public IActionResult Login()
    {
        // Eğer kullanıcı zaten kimlik doğrulaması yapmışsa, ana sayfaya yönlendir
        if (User.Identity.IsAuthenticated)
        {
            return RedirectToAction("Index", "Home");
        }
        // Giriş sayfasını göster
        return View();
    }

    // Kullanıcı giriş yapmaya çalıştığında çalışacak POST metodu
    [HttpPost]
    public async Task<IActionResult> Login(VMLogin modelLogin)
    {
        // Veritabanında kullanıcıyı e-posta ve şifre ile kontrol et
        var user = await _context.Kullanicis
                                 .FirstOrDefaultAsync(u => u.Email == modelLogin.Email &&
                                                           u.Sifre == modelLogin.Sifre);
        if (user != null)
        {
            var roller = _context.KullaniciRoles.Where(d => d.KullaniciID == user.KullaniciID).ToList();
            // Kullanıcı bulundu, claimlerle kimlik oluştur
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Email),
                new Claim(ClaimTypes.Name, user.KullaniciAdi),
            };
            foreach (var role in roller)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.Code));
            }
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                IsPersistent = modelLogin.KeepLoggedIn
            };

            // Kullanıcıyı oturum açma işlemi ile sisteme dahil et
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                                          new ClaimsPrincipal(claimsIdentity),
                                          authProperties);

            return RedirectToAction("Index", "Home");
        }
        else
        {
            ModelState.AddModelError(string.Empty, "Şifre veya mail adresi hatalı !!!");
            return View(modelLogin);
        }
    }
}
