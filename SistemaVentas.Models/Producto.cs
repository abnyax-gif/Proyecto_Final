using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaVentas.Models;

[Table("Productos")]
public class Producto
{
    [Key]
    [Column("id_producto")]
    public int IdProducto { get; set; }

    [Required]
    [StringLength(50)]
    [Column("producto")]
    public string NombreProducto { get; set; } = string.Empty;

    [Required]
    [Column("id_marca")]
    public int IdMarca { get; set; }

    [ForeignKey(nameof(IdMarca))]
    public Marca? Marca { get; set; }

    [StringLength(250)]
    [Column("descripcion")]
    public string? Descripcion { get; set; }

    [StringLength(250)]
    [Column("imagen")]
    public string? Imagen { get; set; }

    [Column("precio_costo", TypeName = "decimal(10,2)")]
    public decimal PrecioCosto { get; set; }

    [Column("precio_venta", TypeName = "decimal(10,2)")]
    public decimal PrecioVenta { get; set; }

    [Column("existencia")]
    public int Existencia { get; set; }

    [Column("fecha_ingreso")]
    public DateTime FechaIngreso { get; set; } = DateTime.Now;
}