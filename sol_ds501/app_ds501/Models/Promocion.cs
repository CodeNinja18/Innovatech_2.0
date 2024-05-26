using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace app_ds501.Models
{
    [Table("tb_promocion")]
    public class Promocion
    {
        [Key]
        [Required(ErrorMessage = "Escriba su codigo de promocion")]
        [MinLength(5, ErrorMessage = "Escriba 5 digitos")]
        [Display(Name = "Codigo promocion")]
        public String codigo_promocion { get; set; }

        [Required(ErrorMessage = "Escriba nombre de la promocion")]
        [StringLength(100)]
        [Display(Name = "Nombre promocion")]
        public String nombre { get; set; }

        [Required(ErrorMessage = "Escriba descripcion de la promocion")]
        [StringLength(100)]
        [Display(Name = "Descripcion promocion")]
        public String descripcion { get; set; }
    }

}
