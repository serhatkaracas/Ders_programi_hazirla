using System.ComponentModel.DataAnnotations;

namespace WebProjeOdev.Models
{
    public class Role
    {
        [Key]
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
