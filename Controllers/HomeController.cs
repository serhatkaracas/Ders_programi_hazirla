using WebProjeOdev.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace WebProjeOdev.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _context;

        public HomeController(ILogger<HomeController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Access");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult SinifSec()
        {
            ViewBag.Siniflar = _context.Sinifs.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult DersProgramiHazirla(int sinifId)
        {
            var sinif = _context.Sinifs
                .Include(s => s.Dersler)
                .ThenInclude(d => d.Ogretmen)
                .Include(s => s.Dersler)
                .ThenInclude(d => d.Derslik)
                .FirstOrDefault(s => s.SinifID == sinifId);

            return View(sinif);
        }

        public IActionResult OgretmenSec()
        {
            ViewBag.Ogretmenler = _context.Ogretmens.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult OgretmenDersProgramiHazirla(int ogretmenId)
        {
            var ogretmen = _context.Ogretmens
                .Include(o => o.Dersler)
                .ThenInclude(d => d.Sinif)
                .Include(o => o.Dersler)
                .ThenInclude(d => d.Derslik)
                .FirstOrDefault(o => o.OgretmenID == ogretmenId);

            return View(ogretmen);
        }
    }
}
