using System.ComponentModel.DataAnnotations;

namespace JWTAPI.Data
{
    public class Area
    {
        public int IdArea { get; set; }

        [Required]
        [MaxLength(50)]
        public string? NameArea { get; set; }
        public string? Distributor { get; set; }
    }

}
