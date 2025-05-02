using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebAPICore_RestMaca.Entidades;

public class Plato
{
    public int Id { get; set; }

     [MaxLength(50)]
    public string Nombre { get; set; } = string.Empty;
    [MaxLength(100)]
    public string Descripcion { get; set; } = string.Empty;

    //[PrecisionAndScale(6, 2, ErrorMessage = "Total Cost must not exceed $9999.99")]

     [Precision(8, 2)]
    public decimal Precio { get; set; }
    public string Imagen { get; set; } = string.Empty;

  
}
    
