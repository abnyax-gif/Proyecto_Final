using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaVentas.Models;

[Table("Empleados")]
public class Empleado
{
    [Key]
    [Column("id_empleado")]
    public int IdEmpleado { get; set; }

    [Required]
    [StringLength(20)]
    [Column("codigo")]
    public string Codigo { get; set; } = string.Empty;

    [Required]
    [StringLength(60)]
    [Column("nombres")]
    public string Nombres { get; set; } = string.Empty;

    [Required]
    [StringLength(60)]
    [Column("apellidos")]
    public string Apellidos { get; set; } = string.Empty;

    [StringLength(100)]
    [Column("direccion")]
    public string? Direccion { get; set; }

    [StringLength(15)]
    [Column("telefono")]
    public string? Telefono { get; set; }

    [Column("fecha_nacimiento")]
    public DateTime? FechaNacimiento { get; set; }

    [Required]
    [Column("id_puesto")]
    public int IdPuesto { get; set; }

    [ForeignKey(nameof(IdPuesto))]
    public Puesto? Puesto { get; set; }

    [Column("fecha_ingreso")]
    public DateTime? FechaIngreso { get; set; }
}