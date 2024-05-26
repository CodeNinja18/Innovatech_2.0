using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace app_ds501.Models
{
    [Table("tb_metodo")]
    public class Metodo
    {
        [Key]
        [Required(ErrorMessage = "Escriba su codigo de metodo de pago")]
        [MinLength(5, ErrorMessage = "Escriba 5 digitos")]
        [Display(Name = "Codigo metodo pago")]
        public String codigo_metodo { get; set; }

        [Required(ErrorMessage = "Escriba nombre de metodo de pago")]
        [StringLength(100)]
        [Display(Name = "Nombre metodo pago")]
        public String nombre { get; set; }

        [Required(ErrorMessage = "Escriba descripcion del metodo pago")]
        [StringLength(100)]
        [Display(Name = "Descripcion metodo pago")]
        public String descripcion { get; set; }
    }

}
