using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaVentas.Models;

[Table("compras")]
public class Compra
{
    [Key]
    [Column("id_compra")]
    public int IdCompra { get; set; }

    [Column("id_proveedor")]
    public int IdProveedor { get; set; }

    [Column("id_empleado")]
    public int IdEmpleado { get; set; }

    [Column("fecha_compra")]
    public DateTime FechaCompra { get; set; } = DateTime.Now;

    [Column("total")]
    public decimal Total { get; set; }
}