using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebProjeOdev.Models
{
    public class Ders
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ders adı gereklidir.")]
        [Display(Name = "Ders Adı")]
        public string DersAdi { get; set; }

        [Display(Name = "Öğretmen Id")]
        public int? OgretmenID { get; set; }

        [ForeignKey("OgretmenID")]
        public Ogretmen Ogretmen { get; set; }

        [Display(Name = "Sınıf Id")]
        public int? SinifID { get; set; }

        [ForeignKey("SinifID")]
        public Sinif Sinif { get; set; }

        [Display(Name = "Derslik Id")]
        public int? DerslikID { get; set; }

        [ForeignKey("DerslikID")]
        public Derslik Derslik { get; set; }

        [Display(Name = "Gün")]
        public string? Gun { get; set; }

        [Display(Name = "Başlangıç Saati")]
        public string? Saat { get; set; }

        [Display(Name = "Toplam Saat")]
        public int? ToplamSaat { get; set; }
    }
}
