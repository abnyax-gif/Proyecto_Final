using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaVentas.API.Data;
using SistemaVentas.Models;

namespace SistemaVentas.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PuestosController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public PuestosController(ApplicationDbContext context)
    {
        _context = context;
    }

    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Puesto>>> GetPuestos([FromQuery] string? buscar)
    {
        var query = _context.Puestos.AsQueryable();

        // Filtro / Búsqueda
        if (!string.IsNullOrWhiteSpace(buscar))
        {
            query = query.Where(p => p.NombrePuesto.Contains(buscar));
        }

        return await query.ToListAsync();
    }

   
    [HttpGet("{id}")]
    public async Task<ActionResult<Puesto>> GetPuesto(int id)
    {
        var puesto = await _context.Puestos.FindAsync(id);

        if (puesto == null)
        {
            return NotFound(new { mensaje = "El puesto no fue encontrado." });
        }

        return puesto;
    }

    
    [HttpPost]
    public async Task<ActionResult<Puesto>> PostPuesto(Puesto puesto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _context.Puestos.Add(puesto);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetPuesto), new { id = puesto.IdPuesto }, puesto);
    }

   
    [HttpPut("{id}")]
    public async Task<IActionResult> PutPuesto(int id, Puesto puesto)
    {
        if (id != puesto.IdPuesto)
        {
            return BadRequest(new { mensaje = "El ID del puesto no coincide." });
        }

        _context.Entry(puesto).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Puestos.Any(e => e.IdPuesto == id))
            {
                return NotFound(new { mensaje = "El puesto a modificar no existe." });
            }
            throw;
        }

        return NoContent();
    }

    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePuesto(int id)
    {
        var puesto = await _context.Puestos.FindAsync(id);
        if (puesto == null)
        {
            return NotFound(new { mensaje = "El puesto no existe." });
        }

        _context.Puestos.Remove(puesto);
        await _context.SaveChangesAsync();

        return Ok(new { mensaje = "Puesto eliminado correctamente." });
    }
}