using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaVentas.Models;

[Table("Compras_Detalle")]
public class CompraDetalle
{
    [Key]
    [Column("id_compra_detalle")]
    public int IdCompraDetalle { get; set; }

    [Column("id_compra")]
    public int IdCompra { get; set; }

    [ForeignKey(nameof(IdCompra))]
    public Compra? Compra { get; set; }

    [Required]
    [Column("id_producto")]
    public int IdProducto { get; set; }

    [ForeignKey(nameof(IdProducto))]
    public Producto? Producto { get; set; }

    [Required(ErrorMessage = "La cantidad es obligatoria.")]
    [Column("cantidad")]
    public int Cantidad { get; set; }

    [Required(ErrorMessage = "El precio de costo es obligatorio.")]
    [Column("precio_costo_unitario", TypeName = "decimal(10,2)")]
    public decimal PrecioCostoUnitario { get; set; }
}