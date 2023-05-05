using System.ComponentModel.DataAnnotations;

namespace JWTAPI.Models
{
    public class Area
    {
        [Key] public int MaArea { get; set; }

        [Required]
        [MaxLength(50)]
        public string? TenArea { get; set; }
        public string? Distributor { get; set; }


    }
}
