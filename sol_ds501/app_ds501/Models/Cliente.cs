using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace app_ds501.Models
{
    [Table("tb_cliente")]
    public class Cliente
    {
        [Key]
        [Required(ErrorMessage = "Escriba su codigo de cliente")]
        [MinLength(5, ErrorMessage = "Escriba 5 digitos")]
        [Display(Name = "Codigo Cliente")]
        public String codigo_cliente { get; set; }

        [Required(ErrorMessage = "Escriba el DNI del cliente")]
        [StringLength(8)]
        [Display(Name = "DNI Cliente")]
        public String identificacion { get; set; }

        [Required(ErrorMessage = "Escriba el nombre del cliente")]
        [StringLength(100)]
        [Display(Name = "Nombre Cliente")]
        public String nombre { get; set; }

        [Required(ErrorMessage = "Escriba el telefono del cliente")]
        [StringLength(8)]
        [Display(Name = "Telefono Cliente")]
        public String telefono { get; set; }
    }

}
