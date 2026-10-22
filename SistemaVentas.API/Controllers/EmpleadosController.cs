using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaVentas.API.Data;
using SistemaVentas.Models;

namespace SistemaVentas.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmpleadosController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public EmpleadosController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Empleado>>> GetEmpleados()
    {
        return await _context.Empleados.Include(e => e.Puesto).ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Empleado>> PostEmpleado(Empleado empleado)
    {
        _context.Empleados.Add(empleado);
        await _context.SaveChangesAsync();
        return Ok(empleado);
    }
}