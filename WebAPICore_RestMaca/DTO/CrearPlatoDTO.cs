using System.ComponentModel.DataAnnotations;

namespace WebAPICore_RestMaca.DTO;

public record class CrearPlatoDTO(
    [Required] [StringLength(30)] string nombre,
    [Required] [StringLength(50)] string descripcion,
    [Required] [Range(10000,100000)] decimal precio,
    [Required] string imagen);

