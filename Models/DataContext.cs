using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebProjeOdev.Models
{
    public class DataContext: IdentityDbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Ders> Derss { get; set; }
        public DbSet<Derslik> Dersliks { get; set; }
        public DbSet<Kullanici> Kullanicis { get; set; }
        public DbSet<Ogretmen> Ogretmens { get; set; }
        public DbSet<Sinif> Sinifs { get; set; }
        public DbSet<Role> Rolles { get; set; }
        public DbSet<KullaniciRole> KullaniciRoles { get; set; }


    }
}
