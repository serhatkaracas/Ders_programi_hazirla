using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebProjeOdev.Models;
using System.Linq;

namespace WebProjeOdev.Controllers
{
    public class OgretmenController : Controller
    {
        private readonly DataContext context;

        public OgretmenController(DataContext _context)
        {
            context = _context;
        }

        [Authorize(Roles = "ADMIN")]
        [HttpGet]
        public IActionResult OgretmenGetir()
        {
            return View();
        }

        [Authorize(Roles = "ADMIN")]
        [HttpPost]
        public IActionResult OgretmenGetir(Ogretmen entity)
        {
            if (entity.OgretmenID != 0) // Eğer OgretmenID 0 değilse, güncelleme işlemi yapılır.
            {
                context.Ogretmens.Update(entity);
            }
            else // Eğer OgretmenID 0 ise, yeni öğretmen eklenir.
            {
                context.Ogretmens.Add(entity);
            }
            context.SaveChanges(); // Değişiklikleri veritabanına kaydeder.
            return RedirectToAction("OgretmenIndex"); // İşlem tamamlandıktan sonra OgretmenIndex sayfasına yönlendirir.
        }

        [HttpGet]
        public IActionResult OgretmenIndex()
        {
            var ogretmenler = context.Ogretmens.Include(o => o.Dersler).ToList();
            return View(ogretmenler);
        }

        [Authorize(Roles = "ADMIN")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var ogretmen = context.Ogretmens.Find(id);
            if (ogretmen == null)
            {
                return NotFound(); // Öğretmen bulunamazsa, 404 hata sayfası döndürür.
            }
            return View("OgretmenGuncelle", ogretmen); // Öğretmen bilgileri ile birlikte düzenleme sayfasını döndürür.
        }

        [Authorize(Roles = "ADMIN")]
        [HttpPost]
        public IActionResult Edit(Ogretmen entity)
        {
            var ogretmen = context.Ogretmens.Find(entity.OgretmenID);
            if (ogretmen == null)
            {
                return NotFound(); // Öğretmen bulunamazsa, 404 hata sayfası döndürür.
            }

            // Öğretmenin bilgilerini günceller.
            ogretmen.AdSoyad = entity.AdSoyad;
            ogretmen.BosGun = entity.BosGun;

            context.Entry(ogretmen).State = EntityState.Modified; // Değişikliklerin takip edilmesini sağlar.
            context.SaveChanges(); // Değişiklikleri veritabanına kaydeder.
            return RedirectToAction("OgretmenIndex"); // İşlem tamamlandıktan sonra OgretmenIndex sayfasına yönlendirir.
        }

        [Authorize(Roles = "ADMIN")]
        public IActionResult Delete(int id)
        {
            var ogretmen = context.Ogretmens.Find(id);
            if (ogretmen != null)
            {
                context.Ogretmens.Remove(ogretmen); // Öğretmeni veritabanından siler.
                context.SaveChanges(); // Değişiklikleri veritabanına kaydeder.
            }
            return RedirectToAction("OgretmenIndex"); // İşlem tamamlandıktan sonra OgretmenIndex sayfasına yönlendirir.
        }
    }
}
