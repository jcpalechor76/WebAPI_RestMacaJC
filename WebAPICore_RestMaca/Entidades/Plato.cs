namespace WebAPICore_RestMaca.Entidades;

public class Plato
{
    public int Id { get; set; }
    public required string Nombre { get; set; } = string.Empty;
    public required string Descripcion { get; set; } = string.Empty;

    public required decimal Precio { get; set; }
    public required string Imagen { get; set; } = string.Empty;
    
}
