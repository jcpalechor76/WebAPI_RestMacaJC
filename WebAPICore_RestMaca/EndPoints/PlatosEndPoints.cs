
using Microsoft.EntityFrameworkCore;
using WebAPICore_RestMaca.Datos;
using WebAPICore_RestMaca.DTO;
using WebAPICore_RestMaca.Entidades;

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
        

        group.MapGet("/", async(AppDBContext dbContext) =>
        {
            var platos = await dbContext.Platos.ToListAsync();
            return Results.Ok(platos);
        }).WithName("GetPlatos");

        group.MapGet("/{id}",async (int id, AppDBContext dbContext) =>
        {
            var plato = await dbContext.Platos.FindAsync(id);
            if (plato == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(plato);
        }).WithName(GetPlatoEndpoint);
        

        group.MapPost("/", async (CrearPlatoDTO nuevoPlato, AppDBContext dbContext) =>
        {
            var plato = new Plato
            {
                Nombre = nuevoPlato.nombre,
                Descripcion = nuevoPlato.descripcion,
                Precio = nuevoPlato.precio,
                Imagen = nuevoPlato.imagen
            };
            dbContext.Platos.Add(plato);
            await dbContext.SaveChangesAsync();

            PlatoDTO platoCreado = new PlatoDTO(plato.Id, plato.Nombre, plato.Descripcion, plato.Precio, plato.Imagen);
            return Results.CreatedAtRoute(GetPlatoEndpoint, new { id = plato.Id }, platoCreado);            
            
        }).WithName("CreatePlato");

        group.MapPut("/{id}", async (int id, CrearPlatoDTO platoActualizado, AppDBContext dbContext) =>
        {
            var plato = await dbContext.Platos.FindAsync(id);
            if (plato == null)
            {
                return Results.NotFound();
            }
            plato.Nombre = platoActualizado.nombre;
            plato.Descripcion = platoActualizado.descripcion;
            plato.Precio = platoActualizado.precio;
            plato.Imagen = platoActualizado.imagen;
            await dbContext.SaveChangesAsync();
            return Results.NoContent();
        }).WithName("UpdatePlato"); 

        return group;
    }
}