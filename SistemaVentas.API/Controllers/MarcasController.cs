using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaVentas.API.Data;
using SistemaVentas.Models;

namespace SistemaVentas.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MarcasController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public MarcasController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Marca>>> GetMarcas()
    {
        return await _context.Marcas.ToListAsync();
    }
}