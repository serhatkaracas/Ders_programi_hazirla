using System.Collections.Generic;

namespace WebProjeOdev.Models
{
    public class Ogretmen
    {
        public int OgretmenID { get; set; }
        public string AdSoyad { get; set; }
        public string BosGun { get; set; }

        // Bir öğretmenin birden fazla dersi olabilir
        public ICollection<Ders> Dersler { get; set; }
    }
}

