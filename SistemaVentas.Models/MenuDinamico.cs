using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaVentas.Models;

[Table("Menu_Dinamico")]
public class MenuDinamico
{
    [Key]
    [Column("id_menu")]
    public int IdMenu { get; set; }

    [Required(ErrorMessage = "El título del menú es obligatorio.")]
    [StringLength(50)]
    [Column("titulo")]
    public string Titulo { get; set; } = string.Empty;

    [StringLength(50)]
    [Column("icono")]
    public string? Icono { get; set; }

    [StringLength(100)]
    [Column("url")]
    public string? Url { get; set; }

    [Column("id_padre")]
    public int? IdPadre { get; set; }

    [Column("orden")]
    public int Orden { get; set; }
}