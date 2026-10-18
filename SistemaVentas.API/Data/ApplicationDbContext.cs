using Microsoft.EntityFrameworkCore;
using SistemaVentas.Models;

namespace SistemaVentas.API.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Puesto> Puestos { get; set; }
    public DbSet<Empleado> Empleados { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Proveedor> Proveedores { get; set; }
    public DbSet<Marca> Marcas { get; set; }
    public DbSet<Producto> Productos { get; set; }
    public DbSet<Compra> Compras { get; set; }
    public DbSet<CompraDetalle> ComprasDetalle { get; set; }
    public DbSet<Venta> Ventas { get; set; }
    public DbSet<VentaDetalle> VentasDetalle { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<MenuDinamico> MenuDinamico { get; set; }
}