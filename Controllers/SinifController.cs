using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebProjeOdev.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace WebProjeOdev.Controllers
{
    public class SinifController : Controller
    {
        private readonly DataContext context;

        public SinifController(DataContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var siniflar = context.Sinifs.Include(s => s.Dersler).ToList();
            return View(siniflar);
        }

        [Authorize(Roles = "ADMIN")]
        [HttpGet]
        public IActionResult SinifGetir()
        {
            return View();
        }

        [Authorize(Roles = "ADMIN")]
        [HttpPost]
        public IActionResult SinifGetir(Sinif entity)
        {
            if (entity.SinifID != 0) // Eğer SinifID 0 değilse, güncelleme işlemi yapılır.
            {
                context.Sinifs.Update(entity);
            }
            else // Eğer SinifID 0 ise, yeni sınıf eklenir.
            {
                context.Sinifs.Add(entity);
            }
            context.SaveChanges(); // Değişiklikleri veritabanına kaydeder.
            return RedirectToAction("Index"); // İşlem tamamlandıktan sonra Index sayfasına yönlendirir.
        }

        [Authorize(Roles = "ADMIN")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var sinif = context.Sinifs.Find(id);
            if (sinif == null)
            {
                return NotFound(); // Sınıf bulunamazsa, 404 hata sayfası döndürür.
            }
            return View("SinifGuncelle", sinif); // Sınıf bilgileri ile birlikte düzenleme sayfasını döndürür.
        }

        [Authorize(Roles = "ADMIN")]
        [HttpPost]
        public IActionResult Edit(Sinif entity)
        {
            var sinif = context.Sinifs.Find(entity.SinifID);
            if (sinif == null)
            {
                return NotFound(); // Sınıf bulunamazsa, 404 hata sayfası döndürür.
            }

            // Sınıfın bilgilerini günceller.
            sinif.SinifSeviyesi = entity.SinifSeviyesi;
            sinif.Mevcut = entity.Mevcut;

            context.Entry(sinif).State = EntityState.Modified; // Değişikliklerin takip edilmesini sağlar.
            context.SaveChanges(); // Değişiklikleri veritabanına kaydeder.
            return RedirectToAction("Index"); // İşlem tamamlandıktan sonra Index sayfasına yönlendirir.
        }

        [Authorize(Roles = "ADMIN")]
        public IActionResult Delete(int id)
        {
            var sinif = context.Sinifs.Find(id);
            if (sinif != null)
            {
                context.Sinifs.Remove(sinif); // Sınıfı veritabanından siler.
                context.SaveChanges(); // Değişiklikleri veritabanına kaydeder.
            }
            return RedirectToAction("Index"); // İşlem tamamlandıktan sonra Index sayfasına yönlendirir.
        }
    }
}
