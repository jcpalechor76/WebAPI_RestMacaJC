using System.ComponentModel.DataAnnotations;

namespace WebAPICore_RestMaca.DTO;

public record class ActualizarPlatoDTO(
   [Required(ErrorMessage = "{0} es obligatorio")][StringLength(50, MinimumLength = 3, ErrorMessage = "{0} debe tener entre {2} y {1} caracteres")] string nombre,
   [Required(ErrorMessage = "{0} es obligatorio")][StringLength(100, MinimumLength = 5, ErrorMessage = "{0} debe tener entre {2} y {1} caracteres")] string descripcion,
   [Required(ErrorMessage = "{0} es obligatorio")][Range(10000, 100000, ErrorMessage = "{0} debe tener valor entre {2} y {1}")] decimal precio,
   [Required(ErrorMessage = "{0} es obligatorio")] string imagen);