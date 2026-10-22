using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaVentas.Models;

[Table("menu_dinamico")]
public class MenuDinamico
{
    [Key]
    [Column("id_menu")]
    public int IdMenu { get; set; }

    [Column("nombre_menu")]
    public string NombreMenu { get; set; } = string.Empty;

    [Column("url")]
    public string? Url { get; set; }

    [Column("icono")]
    public string? Icono { get; set; }

    [Column("rol")]
    public string? Rol { get; set; }

    [Column("orden")]
    public int Orden { get; set; }
}