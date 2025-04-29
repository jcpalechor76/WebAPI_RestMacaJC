namespace WebAPICore_RestMaca.DTO;

public record class PlatoDTO(
    int id, 
    string nombre,
    string descripcion,
    decimal precio,
    string imagen);

