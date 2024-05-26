using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace app_ds501.Models
{
    [Table("tb_servicio")]
    public class Servicio
    {
        [Key]
        [Required(ErrorMessage = "Escriba su codigo de servicio")]
        [MinLength(5, ErrorMessage = "Escriba 5 digitos")]
        [Display(Name = "Codigo Servicio")]
        public String codigo_servicio { get; set; }

        [Required(ErrorMessage = "Escriba nombre del servicio")]
        [StringLength(100)]
        [Display(Name = "Nombre Servicio")]
        public String nombre { get; set; }

        [Required(ErrorMessage = "Escriba descripcion del servicio")]
        [StringLength(100)]
        [Display(Name = "Descripcion servicio")]
        public String descripcion { get; set; }
    }

}
