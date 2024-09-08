namespace WebProjeOdev.Models
{
    public class Sinif
    {
        public int SinifID { get; set; }
        public string SinifSeviyesi { get; set; }
        public int Mevcut { get; set; }

        // Bir sınıfın birden fazla dersi olabilir
        public ICollection<Ders> Dersler { get; set; }
    }
}
