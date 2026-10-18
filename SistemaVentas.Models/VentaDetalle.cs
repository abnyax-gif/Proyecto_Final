using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaVentas.Models;

[Table("Ventas_Detalle")]
public class VentaDetalle
{
    [Key]
    [Column("id_venta_detalle")]
    public int IdVentaDetalle { get; set; }

    [Column("id_venta")]
    public int IdVenta { get; set; }

    [ForeignKey(nameof(IdVenta))]
    public Venta? Venta { get; set; }

    [Required]
    [Column("id_producto")]
    public int IdProducto { get; set; }

    [ForeignKey(nameof(IdProducto))]
    public Producto? Producto { get; set; }

    [Required(ErrorMessage = "La cantidad es obligatoria.")]
    [Column("cantidad")]
    public int Cantidad { get; set; }

    [Required]
    [Column("precio_unitario", TypeName = "decimal(10,2)")]
    public decimal PrecioUnitario { get; set; }
}