using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.ComponentModel.DataAnnotations.Schema;


namespace ExamenUnidad2.Dtos.IMC
{
    public class IMCCreateDto
    {
        [Display (Name = "Nombre")]
        public string Name { get; set; }
        public string Genero { get; set; }
        public decimal Altura { get; set; }

        public decimal Peso { get; set; }
    }
}
