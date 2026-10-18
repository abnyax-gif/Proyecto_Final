using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaVentas.Models;

[Table("Compras")]
public class Compra
{
    [Key]
    [Column("id_compra")]
    public int IdCompra { get; set; }

    [Required(ErrorMessage = "El número de orden de compra es obligatorio.")]
    [Column("no_orden_compra")]
    public int NoOrdenCompra { get; set; }

    [Required(ErrorMessage = "Debe seleccionar un proveedor.")]
    [Column("id_proveedor")]
    public int IdProveedor { get; set; }

    [ForeignKey(nameof(IdProveedor))]
    public Proveedor? Proveedor { get; set; }

    [Column("fecha_orden")]
    public DateTime FechaOrden { get; set; } = DateTime.Now;

    [Column("fecha_ingreso")]
    public DateTime FechaIngreso { get; set; } = DateTime.Now;

    // Relación Maestro-Detalle
    public List<CompraDetalle> Detalles { get; set; } = new();
}