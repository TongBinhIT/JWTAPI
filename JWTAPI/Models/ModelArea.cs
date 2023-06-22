using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JWTAPI.Models
{
    public class ModelArea
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Key] 
        public int IdArea { get; set; }

        [Required]
        [MaxLength(50)]
        public string? NameArea { get; set; }
        public string? Distributor { get; set; }
    }
}
