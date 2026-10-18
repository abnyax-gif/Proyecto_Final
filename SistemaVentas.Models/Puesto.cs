using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaVentas.Models;

[Table("Puestos")]
public class Puesto
{
    [Key]
    [Column("id_puesto")]
    public int IdPuesto { get; set; }

    [Required(ErrorMessage = "El nombre del puesto es obligatorio.")]
    [StringLength(50, ErrorMessage = "El puesto no puede superar los 50 caracteres.")]
    [Column("puesto")]
    public string NombrePuesto { get; set; } = string.Empty;
}