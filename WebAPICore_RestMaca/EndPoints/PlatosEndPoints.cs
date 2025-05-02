
using Microsoft.EntityFrameworkCore;
using WebAPICore_RestMaca.Datos;
using WebAPICore_RestMaca.DTO;
using WebAPICore_RestMaca.Entidades;
using WebAPICore_RestMaca.Repositorios;

namespace WebAPICore_RestMaca.EndPoints;

public static class PlatosEndPoints
{
    const string GetPlatoEndpoint = "GetPlatoById";
   

    public static RouteGroupBuilder MapPlatosEndPoints(this WebApplication app)
    {
        var group = app.MapGroup("Platos").WithParameterValidation();
        
        

        group.MapGet("/", async(IPlatosRepositorio repositorio) =>
        
        (await repositorio.GetAllPlatosAsync()).Select(p => new PlatoDTO(p.Id, p.Nombre, p.Descripcion, p.Precio, p.Imagen)));            
            
        group.MapGet("/{id}",async (int id, IPlatosRepositorio repositorio) =>
        {
            Plato? plato = await repositorio.GetPlatoAsync(id);
            return plato is null ? Results.NotFound() : Results.Ok(new PlatoDTO(plato.Id, plato.Nombre, plato.Descripcion, plato.Precio, plato.Imagen));
        }).WithName(GetPlatoEndpoint);
        

        group.MapPost("/", async (IPlatosRepositorio repositorio, CrearPlatoDTO nuevoPlato) =>
        {
            var plato = new Plato
            {
                Nombre = nuevoPlato.nombre,
                Descripcion = nuevoPlato.descripcion,
                Precio = nuevoPlato.precio,
                Imagen = nuevoPlato.imagen
            };
            await repositorio.CreatePlatoAsync(plato);
            return Results.CreatedAtRoute(GetPlatoEndpoint, new { id = plato.Id }, plato);            
            
        }).WithName("CreatePlato");

        group.MapPut("/{id}", async (IPlatosRepositorio repositorio,int id, CrearPlatoDTO platoActualizado) =>
        {
            Plato? plato = await repositorio.GetPlatoAsync(id);
            if (plato == null)
            {
                return Results.NotFound();
            }
            plato.Nombre = platoActualizado.nombre;
            plato.Descripcion = platoActualizado.descripcion;
            plato.Precio = platoActualizado.precio;
            plato.Imagen = platoActualizado.imagen;

            await repositorio.UpdatePlatoAsync(plato);
            return Results.NoContent();
            
        }).WithName("UpdatePlato"); 

        return group;
    }
}