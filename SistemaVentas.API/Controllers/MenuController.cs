using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaVentas.API.Data;
using SistemaVentas.Models;

namespace SistemaVentas.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MenuController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public MenuController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MenuDinamico>>> GetMenus()
    {
        return await _context.MenusDinamicos.ToListAsync();
    }

    [HttpGet("por-rol/{rol}")]
    public async Task<ActionResult<IEnumerable<MenuDinamico>>> GetMenusPorRol(string rol)
    {
        return await _context.MenusDinamicos
            .Where(m => m.Rol == rol || m.Rol == "Todos" || string.IsNullOrEmpty(m.Rol))
            .ToListAsync();
    }
}