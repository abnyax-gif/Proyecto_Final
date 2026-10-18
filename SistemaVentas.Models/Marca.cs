using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaVentas.Models;

[Table("Marcas")]
public class Marca
{
    [Key]
    [Column("id_marca")]
    public int IdMarca { get; set; }

    [Required]
    [StringLength(50)]
    [Column("marca")]
    public string NombreMarca { get; set; } = string.Empty;
}