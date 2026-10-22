using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaVentas.Models;

[Table("compras_detalle")]
public class CompraDetalle
{
    [Key]
    [Column("id_compra_detalle")]
    public int IdCompraDetalle { get; set; }

    [Column("id_compra")]
    public int IdCompra { get; set; }

    [Column("id_producto")]
    public int IdProducto { get; set; }

    [Column("cantidad")]
    public int Cantidad { get; set; }

    [Column("precio_costo")]
    public decimal PrecioCosto { get; set; }
}