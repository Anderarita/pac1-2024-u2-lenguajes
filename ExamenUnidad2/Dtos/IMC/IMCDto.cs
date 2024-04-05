using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace ExamenUnidad2.Dtos.IMC
{
    public class IMCDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Genero { get; set; }
        public decimal Altura { get; set; }

        public decimal Peso { get; set;}


    }
}
