using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.ComponentModel.DataAnnotations.Schema;


namespace ExamenUnidad2.Dtos.IMC
{
    public class IMCCreateDto
    {
        [Required (ErrorMessage = "debe ser obligatorio el nombre")]
        [Display (Name = "Nombre")]
        public string Name { get; set; }
        [Required(ErrorMessage = "debe ser obligatorio el Genero")]
        public string Genero { get; set; }
        [Required(ErrorMessage = "debe ser obligatorio el Altura")]
        public decimal Altura { get; set; }
        [Required(ErrorMessage = "debe ser obligatorio el Peso")]

        public decimal Peso { get; set; }

        public string resultado { get; set; }
    }
}
