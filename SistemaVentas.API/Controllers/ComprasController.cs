using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaVentas.API.Data;
using SistemaVentas.Models;

namespace SistemaVentas.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ComprasController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ComprasController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> PostCompra([FromBody] CompraRequestDTO dto)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            // 1. Crear el Maestro de Compra
            var compra = new Compra
            {
                IdProveedor = dto.IdProveedor,
                IdEmpleado = dto.IdEmpleado,
                FechaCompra = DateTime.Now,
                Total = dto.Total
            };

            _context.Compras.Add(compra);
            await _context.SaveChangesAsync();

            // 2. Crear los Detalles de Compra y actualizar Existencia de Productos
            foreach (var item in dto.Detalles)
            {
                var detalle = new CompraDetalle
                {
                    IdCompra = compra.IdCompra,
                    IdProducto = item.IdProducto,
                    Cantidad = item.Cantidad,
                    PrecioCosto = item.PrecioCosto
                };

                _context.ComprasDetalle.Add(detalle);

                // Incrementar inventario en productos
                var producto = await _context.Productos.FindAsync(item.IdProducto);
                if (producto != null)
                {
                    producto.Existencia += item.Cantidad;
                    if (item.PrecioCosto > 0)
                    {
                        producto.PrecioCosto = item.PrecioCosto;
                    }
                }
            }

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();

            return Ok(new { idCompra = compra.IdCompra });
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            return BadRequest(new { mensaje = "Error al procesar la compra: " + ex.Message });
        }
    }

    public class CompraRequestDTO
    {
        public int IdProveedor { get; set; }
        public int IdEmpleado { get; set; }
        public decimal Total { get; set; }
        public List<CompraDetalleRequestDTO> Detalles { get; set; } = new();
    }

    public class CompraDetalleRequestDTO
    {
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioCosto { get; set; }
    }
}