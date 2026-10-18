using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaVentas.Models;

[Table("Proveedores")]
public class Proveedor
{
    [Key]
    [Column("id_proveedor")]
    public int IdProveedor { get; set; }

    [Required]
    [StringLength(60)]
    [Column("proveedor")]
    public string NombreProveedor { get; set; } = string.Empty;

    [Required]
    [StringLength(15)]
    [Column("nit")]
    public string Nit { get; set; } = string.Empty;

    [StringLength(100)]
    [Column("direccion")]
    public string? Direccion { get; set; }

    [StringLength(15)]
    [Column("telefono")]
    public string? Telefono { get; set; }
}