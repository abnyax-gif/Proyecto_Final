using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaVentas.Models;

[Table("Usuarios")]
public class Usuario
{
    [Key]
    [Column("id_usuario")]
    public int IdUsuario { get; set; }

    [Required(ErrorMessage = "El nombre de usuario es obligatorio.")]
    [StringLength(50)]
    [Column("nombre_usuario")]
    public string NombreUsuario { get; set; } = string.Empty;

    [Required(ErrorMessage = "La contraseña es obligatoria.")]
    [StringLength(255)]
    [Column("clave_hash")]
    public string ClaveHash { get; set; } = string.Empty;

    [Column("id_empleado")]
    public int? IdEmpleado { get; set; }

    [ForeignKey(nameof(IdEmpleado))]
    public Empleado? Empleado { get; set; }

    [Column("activo")]
    public bool Activo { get; set; } = true;
}