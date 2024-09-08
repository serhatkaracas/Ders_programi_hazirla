using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebProjeOdev.Models;

public class DersController : Controller
{
    private readonly DataContext context;

    public DersController(DataContext _context)
    {
        context = _context;
    }

    [HttpGet]
    public IActionResult DersGetir()
    {
        ViewBag.Ogretmenler = context.Ogretmens.ToList();
        ViewBag.Siniflar = context.Sinifs.ToList();
        ViewBag.Derslikler = context.Dersliks.ToList();
        return View();
    }

    [HttpPost]
    public IActionResult DersGetir(Ders entity)
    {
        if (entity.Id != 0)
        {
            context.Derss.Update(entity);
        }
        else
        {
            context.Derss.Add(entity);
        }
        context.SaveChanges();
        return RedirectToAction("DersIndex");
    }

    [HttpGet]
    public IActionResult DersIndex()
    {
        var dersler = context.Derss.Include(d => d.Ogretmen)
                                   .Include(d => d.Sinif)
                                   .Include(d => d.Derslik)
                                   .ToList();
        return View(dersler);
    }

    [Authorize(Roles = "ADMIN")]
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var ders = context.Derss.Find(id);
        if (ders == null)
        {
            return NotFound();
        }
        ViewBag.Ogretmenler = context.Ogretmens.ToList();
        ViewBag.Siniflar = context.Sinifs.ToList();
        ViewBag.Derslikler = context.Dersliks.ToList();
        return View("DersGuncelle", ders);
    }

    [Authorize(Roles = "ADMIN")]
    [HttpPost]
    public IActionResult Edit(Ders entity)
    {
        var ders = context.Derss.Find(entity.Id);
        if (ders == null)
        {
            return NotFound();
        }

        ders.OgretmenID = entity.OgretmenID;
        ders.DersAdi = entity.DersAdi;
        ders.SinifID = entity.SinifID;
        ders.DerslikID = entity.DerslikID;
        ders.Gun = entity.Gun;
        ders.Saat = entity.Saat;
        ders.ToplamSaat = entity.ToplamSaat;

        context.Entry(ders).State = EntityState.Modified;
        context.SaveChanges();
        return RedirectToAction("DersIndex");
    }

    [Authorize(Roles = "ADMIN")]
    public IActionResult Delete(int id)
    {
        var ders = context.Derss.Find(id);
        if (ders != null)
        {
            context.Derss.Remove(ders);
            context.SaveChanges();
        }
        return RedirectToAction("DersIndex");
    }
}
