
using WebAPICore_RestMaca.DTO;

namespace WebAPICore_RestMaca.EndPoints;

public static class PlatosEndPoints
{
    const string GetPlatoEndpoint = "GetPlatoById";
    private static readonly List<PlatoDTO> platos =
[
    new PlatoDTO(1, "Sancocho de gallina", "Delicioso sancocho de gallina", 15000m, "/Imagenes/chicken.jpg"),
    new PlatoDTO(2, "Sancocho de pescado", "Delicioso sancocho de pescado", 15000m, "/Imagenes/fish.jpg"),
    new PlatoDTO(3, "Sancocho de res", "Delicioso sancocho de res", 15000m, "/Imagenes/beef.jpg"),
];

    public static RouteGroupBuilder MapPlatosEndPoints(this WebApplication app)
    {
        var group = app.MapGroup("Platos").WithParameterValidation();
        ;

        group.MapGet("/", () => platos);

        group.MapGet("/{id}", (int id) =>
        {
            var plato = platos.FirstOrDefault(p => p.id == id);
            return plato != null ? Results.Ok(plato) : Results.NotFound();
        }).WithName(GetPlatoEndpoint);

        group.MapPost("/", (CrearPlatoDTO platoDTO) =>
        {
            var nuevoPlato = new PlatoDTO(platos.Count + 1,
                                            platoDTO.nombre,
                                            platoDTO.descripcion,
                                            platoDTO.precio,
                                            platoDTO.imagen);
            platos.Add(nuevoPlato);
            return Results.CreatedAtRoute(GetPlatoEndpoint, new { id = nuevoPlato.id }, nuevoPlato);
        }).WithName("CreatePlato");
        

        group.MapPut("/{id}", (int id, ActualizarPlatoDTO platoDTO) =>
        {
            var index = platos.FindIndex(p => p.id == id);
            if (index == -1)
            {
                return Results.NotFound();
            }
            platos[index] = new PlatoDTO(id,
                                            platoDTO.nombre,
                                            platoDTO.descripcion,
                                            platoDTO.precio,
                                            platoDTO.imagen);
            return Results.NoContent();
        }).WithName("UpdatePlato");

        return group;
    }
}