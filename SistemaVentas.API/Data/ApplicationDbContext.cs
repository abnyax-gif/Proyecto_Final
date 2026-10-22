using Microsoft.EntityFrameworkCore;
using SistemaVentas.Models;

namespace SistemaVentas.API.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    // Mapeo de Tablas
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Compra> Compras { get; set; }
    public DbSet<CompraDetalle> ComprasDetalle { get; set; }
    public DbSet<Empleado> Empleados { get; set; }
    public DbSet<Marca> Marcas { get; set; }
    public DbSet<MenuDinamico> MenuDinamico { get; set; }
    public DbSet<MenuDinamico> MenusDinamicos { get; set; }
    public DbSet<Producto> Productos { get; set; }
    public DbSet<Proveedor> Proveedores { get; set; }
    public DbSet<Puesto> Puestos { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Venta> Ventas { get; set; }
    public DbSet<VentaDetalle> VentasDetalle { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Claves Primarias explícitas
        modelBuilder.Entity<Cliente>().HasKey(c => c.IdCliente);
        modelBuilder.Entity<Compra>().HasKey(c => c.IdCompra);
        modelBuilder.Entity<CompraDetalle>().HasKey(cd => cd.IdCompraDetalle);
        modelBuilder.Entity<Empleado>().HasKey(e => e.IdEmpleado);
        modelBuilder.Entity<Marca>().HasKey(m => m.IdMarca);
        modelBuilder.Entity<MenuDinamico>().HasKey(md => md.IdMenu);
        modelBuilder.Entity<Producto>().HasKey(p => p.IdProducto);
        modelBuilder.Entity<Proveedor>().HasKey(pr => pr.IdProveedor);
        modelBuilder.Entity<Puesto>().HasKey(pu => pu.IdPuesto);
        modelBuilder.Entity<Usuario>().HasKey(u => u.IdUsuario);
        modelBuilder.Entity<Venta>().HasKey(v => v.IdVenta);
        modelBuilder.Entity<VentaDetalle>().HasKey(vd => vd.IdVentaDetalle);
    }
}