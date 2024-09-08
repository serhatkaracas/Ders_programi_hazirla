using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebProjeOdev.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace WebProjeOdev.Controllers
{
    public class DerslikController : Controller
    {
        private readonly DataContext context;

        public DerslikController(DataContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public IActionResult DerslikIndex()
        {
            var derslikler = context.Dersliks.ToList();
            return View(derslikler);
        }

        [Authorize(Roles = "ADMIN")]
        [HttpGet]
        public IActionResult DerslikGetir()
        {
            return View();
        }

        [Authorize(Roles = "ADMIN")]
        [HttpPost]
        public IActionResult DerslikGetir(Derslik entity)
        {
            if (entity.DerslikID != 0) // Eğer DerslikID 0 değilse, güncelleme işlemi yapılır.
            {
                context.Dersliks.Update(entity);
            }
            else // Eğer DerslikID 0 ise, yeni derslik eklenir.
            {
                context.Dersliks.Add(entity);
            }
            context.SaveChanges(); // Değişiklikleri veritabanına kaydeder.
            return RedirectToAction("DerslikIndex"); // İşlem tamamlandıktan sonra DerslikIndex sayfasına yönlendirir.
        }

        [Authorize(Roles = "ADMIN")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var derslik = context.Dersliks.Find(id);
            if (derslik == null)
            {
                return NotFound(); // Derslik bulunamazsa, 404 hata sayfası döndürür.
            }
            return View("DerslikGuncelle", derslik); // Derslik bilgileri ile birlikte düzenleme sayfasını döndürür.
        }

        [Authorize(Roles = "ADMIN")]
        [HttpPost]
        public IActionResult Edit(Derslik entity)
        {
            var derslik = context.Dersliks.Find(entity.DerslikID);
            if (derslik == null)
            {
                return NotFound(); // Derslik bulunamazsa, 404 hata sayfası döndürür.
            }

            // Derslik bilgilerini günceller.
            derslik.DerslikAdi = entity.DerslikAdi;
            derslik.Kapasite = entity.Kapasite;

            context.Entry(derslik).State = EntityState.Modified; // Değişikliklerin takip edilmesini sağlar.
            context.SaveChanges(); // Değişiklikleri veritabanına kaydeder.
            return RedirectToAction("DerslikIndex"); // İşlem tamamlandıktan sonra DerslikIndex sayfasına yönlendirir.
        }

        [Authorize(Roles = "ADMIN")]
        public IActionResult Delete(int id)
        {
            var derslik = context.Dersliks.Find(id);
            if (derslik != null)
            {
                context.Dersliks.Remove(derslik); // Dersliği veritabanından siler.
                context.SaveChanges(); // Değişiklikleri veritabanına kaydeder.
            }
            return RedirectToAction("DerslikIndex"); // İşlem tamamlandıktan sonra DerslikIndex sayfasına yönlendirir.
        }
    }
}
