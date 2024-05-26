using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace app_ds501.Models
{
    [Table("tb_usuario")]
    public class Usuario
    {
        [Key]
        [Required]
        [EmailAddress]
        public string correo { get; set; }

        [Required]
        public string contra { get; set; }
    }
}
