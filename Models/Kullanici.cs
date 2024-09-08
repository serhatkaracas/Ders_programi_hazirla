using System.ComponentModel.DataAnnotations;

namespace WebProjeOdev.Models
{
    public class Kullanici
    {
        [Key]
        public int KullaniciID { get; set; }

        [Required(ErrorMessage = "Kullanıcı adı gereklidir.")]
        public string KullaniciAdi { get; set; }

        [Required(ErrorMessage = "Şifre gereklidir.")]
        public string Sifre { get; set; }

        [Required(ErrorMessage = "E-posta gereklidir.")]
        public string Email { get; set; }

        // Bir kullanıcının birden fazla rolü olabilir
        public ICollection<KullaniciRole> KullaniciRolleri { get; set; }
    }
}
