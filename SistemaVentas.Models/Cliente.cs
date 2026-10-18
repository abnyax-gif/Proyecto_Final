using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaVentas.Models;

[Table("Clientes")]
public class Cliente
{
    [Key]
    [Column("id_cliente")]
    public int IdCliente { get; set; }

    [Required]
    [StringLength(60)]
    [Column("nombres")]
    public string Nombres { get; set; } = string.Empty;

    [Required]
    [StringLength(60)]
    [Column("apellidos")]
    public string Apellidos { get; set; } = string.Empty;

    [Required]
    [StringLength(15)]
    [Column("nit")]
    public string Nit { get; set; } = string.Empty;

    [Column("genero")]
    public bool? Genero { get; set; }

    [StringLength(15)]
    [Column("telefono")]
    public string? Telefono { get; set; }

    [EmailAddress]
    [StringLength(50)]
    [Column("correo_electronico")]
    public string? CorreoElectronico { get; set; }

    [Column("fecha_ingreso")]
    public DateTime FechaIngreso { get; set; } = DateTime.Now;
}