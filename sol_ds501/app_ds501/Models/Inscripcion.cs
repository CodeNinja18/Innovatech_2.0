using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace app_ds501.Models
{

    [Table("tb_inscripcion")]
    public class Inscripcion
    {
        [Key]
        [Required(ErrorMessage = "Escriba su codigo de inscripcion")]
        [MinLength(5, ErrorMessage = "Escriba 5 digitos")]
        [Display(Name = "Codigo Inscripcion")]
        public String? codigo_inscripcion { get; set; }

        [Required(ErrorMessage = "Escriba su número de boleta")]
        [MinLength(6, ErrorMessage = "Escriba 6 digitos")]
        [Display(Name = "N° Boleta")]
        public String? numboleta { get; set; }

        [Required(ErrorMessage = "Escriba el codigo de cliente")]
        [MinLength(5, ErrorMessage = "Escriba 5 digitos")]
        [Display(Name = "Codigo Cliente")]
        public String? inscripcion_codigo_cliente { get; set; }

        [Required(ErrorMessage = "Escriba el codigo de servicio")]
        [MinLength(5, ErrorMessage = "Escriba 5 digitos")]
        [Display(Name = "Codigo Servicio")]
        public String? inscripcion_codigo_servicio { get; set; }

        [Required(ErrorMessage = "Escriba el codigo de promocion")]
        [MinLength(5, ErrorMessage = "Escriba 5 digitos")]
        [Display(Name = "Codigo Promocion")]
        public String? inscripcion_codigo_promocion { get; set; }

        [Required(ErrorMessage = "Escriba el codigo del metodo")]
        [MinLength(5, ErrorMessage = "Escriba 5 digitos")]
        [Display(Name = "Codigo Metodo")]
        public String? inscripcion_codigo_metodo { get; set; }

        [Required(ErrorMessage = "Escriba fecha de emision")]
        [Display(Name = "Emision")]
        [DataType(DataType.Date)]
        public DateTime emision { get; set; }

        [Required(ErrorMessage = "Escriba fecha de caducidad")]
        [Display(Name = "Caducidad")]
        [DataType(DataType.Date)]
        public DateTime caducidad { get; set; }

        [Required(ErrorMessage = "Ingrese el precio")]
        [Display(Name = "Precio")]
        public decimal precio { get; set; }

        [Required(ErrorMessage = "Ingrese pago")]
        [Display(Name = "Pago")]
        public decimal pago { get; set; }

        [Required(ErrorMessage = "Ingrese la deuda")]
        [Display(Name = "Deuda")]
        public decimal deuda { get; set; }

        [Required(ErrorMessage = "Escriba el estado")]
        [StringLength(20)]
        [Display(Name = "Estado")]
        public String? estado { get; set; }

        // Relacionar modelos

        [ForeignKey("inscripcion_codigo_cliente")]
        public Cliente? Cliente { get; set; }

        [ForeignKey("inscripcion_codigo_servicio")]
        public Servicio? Servicio { get; set; }

        [ForeignKey("inscripcion_codigo_promocion")]
        public Promocion? Promocion { get; set; }

        [ForeignKey("inscripcion_codigo_metodo")]
        public Metodo? Metodo { get; set; }
    }
}
