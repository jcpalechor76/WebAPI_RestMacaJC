using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPICore_RestMaca.DTO;
using WebAPICore_RestMaca.Entidades;
using WebAPICore_RestMaca.Repositorios;

namespace WebAPICore_RestMaca.EndPoints
{
    public static class PlatosMemEndPoints
    {
        const string GetPlatoEndpoint = "GetPlatoById";


        public static RouteGroupBuilder MapPlatosMemEndPoints(this WebApplication app)
        {
            var group = app.MapGroup("Platos").WithParameterValidation();



            group.MapGet("/", (IPlatosRepositorio repositorio) =>
            {
                var platos = repositorio.GetAllPlatosAsync();
                return Results.Ok(platos);
            }).WithName("GetPlatos");

            group.MapGet("/{id}", (int id, IPlatosRepositorio repositorio) =>
            {
                var plato = repositorio.GetPlatoAsync(id);
                if (plato == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(plato);
            }).WithName(GetPlatoEndpoint);


            group.MapPost("/", (CrearPlatoDTO nuevoPlato, IPlatosRepositorio repositorio) =>
            {
                var plato = new Plato
                {
                    Nombre = nuevoPlato.nombre,
                    Descripcion = nuevoPlato.descripcion,
                    Precio = nuevoPlato.precio,
                    Imagen = nuevoPlato.imagen
                };
                repositorio.CreatePlatoAsync(plato);

                PlatoDTO platoCreado = new PlatoDTO(plato.Id, plato.Nombre, plato.Descripcion, plato.Precio, plato.Imagen);
                return Results.CreatedAtRoute(GetPlatoEndpoint, new { id = plato.Id }, platoCreado);

            }).WithName("CreatePlato");

            // group.MapPut("/{id}", (int id, ActualizarPlatoDTO platoActualizado, IPlatosRepositorio repositorio) =>
            // {
            //     var plato = repositorio.GetPlatoAsync(id);
            //     if (plato == null)
            //     {
            //         return Results.NotFound();
            //     }
            //     plato.Nombre = platoActualizado.nombre;
            //     plato.Descripcion = platoActualizado.descripcion;
            //     plato.Precio = platoActualizado.precio;
            //     plato.Imagen = platoActualizado.imagen;
            //     repositorio.UpdatePlato(plato);
            //     return Results.NoContent();
            // }).WithName("UpdatePlato");

            return group;
        }
    }
}