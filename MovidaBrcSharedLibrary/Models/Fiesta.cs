
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

        public DateTime FechaRealizacionFiesta { get; set; }

        [Required]
        public TipoFiesta TipoFiesta { get; set; }


    }
}
