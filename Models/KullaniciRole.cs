using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebProjeOdev.Models
{
    public class KullaniciRole
    {
        [Key]
        public int Id { get; set; }

        public int KullaniciID { get; set; }

        [ForeignKey("KullaniciID")]
        public Kullanici Kullanici { get; set; }

        public string Code { get; set; }

        [ForeignKey("Code")]
        public Role Role { get; set; }
    }
}
