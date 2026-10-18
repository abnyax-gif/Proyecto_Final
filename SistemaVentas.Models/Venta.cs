using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaVentas.Models;

[Table("Ventas")]
public class Venta
{
    [Key]
    [Column("id_venta")]
    public int IdVenta { get; set; }

    [Required(ErrorMessage = "El número de factura es obligatorio.")]
    [Column("no_factura")]
    public int NoFactura { get; set; }

    [Required(ErrorMessage = "La serie es obligatoria.")]
    [StringLength(5)]
    [Column("serie")]
    public string Serie { get; set; } = string.Empty;

    [Column("fecha_factura")]
    public DateTime FechaFactura { get; set; } = DateTime.Now;

    [Required(ErrorMessage = "Debe seleccionar un cliente.")]
    [Column("id_cliente")]
    public int IdCliente { get; set; }

    [ForeignKey(nameof(IdCliente))]
    public Cliente? Cliente { get; set; }

    [Required(ErrorMessage = "Debe seleccionar un empleado.")]
    [Column("id_empleado")]
    public int IdEmpleado { get; set; }

    [ForeignKey(nameof(IdEmpleado))]
    public Empleado? Empleado { get; set; }

    [Column("fecha_ingreso")]
    public DateTime FechaIngreso { get; set; } = DateTime.Now;

    // Relación Maestro-Detalle
    public List<VentaDetalle> Detalles { get; set; } = new();
}