using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamenUnidad2.Entities
{
    [Table("IMC", Schema = "transactional")]
    public class IMCEntity
    {
        [Column("id")]
        [Key]
        public Guid Id { get; set; }

        [Column("Nombre")]
        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [Column ("Genero")]
        [Required]
        [StringLength (50)]
        public string Genero { get; set; }

        [Column]
        [Required]
        public decimal Altura { get; set; }

        [Column]
        [Required]
        public decimal Peso { get; set; }
    }
}
