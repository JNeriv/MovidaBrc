
using System.ComponentModel.DataAnnotations;


namespace MovidaBrcSharedLibrary.Models
{
    public class Fiesta
    {
        [Key]
        public int IdFiesta { get; set; }

        [Required]
        public string NombreFiesta { get; set; }
 
        [Required]
        public string DescripcionFiesta { get; set; }

        public DateTime FechaCreacionFiesta { get; } = DateTime.Now;

        [Required]
        public DateTime FechaRealizacionFiesta { get; set; } = DateTime.Now;

        [Required]
        public TipoFiesta TipoFiesta { get; set; }

        [Required]
        public string UbicacionFiesta { get; set; }

        [Required]
        public string ImagenFiesta { get; set; }

        public bool GratisBoolFiesta { get; set; } = false;

        [Required]
        public string HoraFiesta { get; set; }
    }
}
