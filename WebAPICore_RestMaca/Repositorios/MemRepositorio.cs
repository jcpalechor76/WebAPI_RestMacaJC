using WebAPICore_RestMaca.Entidades;
using WebAPICore_RestMaca.Repositorios;

namespace WebAPICore_RestMaca.Datos;

public class DatosMemoria : IPlatosRepositorio
{
    private List<Plato> platos = new List<Plato>(){
        new Plato { Id = 1, Nombre = "Sancocho de gallina", Descripcion = "Delicioso sancocho de gallina en memoria", Precio = 10000m, Imagen = "/Imagenes/chicken.jpg" },
        new Plato { Id = 2, Nombre = "Sancocho de pescado", Descripcion = "Delicioso sancocho de pescado en memoria", Precio = 20000m, Imagen = "/Imagenes/fisch.jpg" },
        new Plato { Id = 3, Nombre = "Sancocho de res", Descripcion = "Delicioso sancocho de res en memoria", Precio = 30000m, Imagen = "/Imagenes/beef.jpg" }
    };

    public async Task CreatePlatoAsync(Plato plato)
    {
        plato.Id = platos.Max(p => p.Id) + 1;
        platos.Add(plato);
        await Task.CompletedTask;
    }

    public async Task<IEnumerable<Plato>> GetAllPlatosAsync()
    {
        return await Task.FromResult(platos);
    }

    public async Task<Plato?> GetPlatoAsync(int id)
    {
        return await Task.FromResult(platos.Find(p => p.Id == id));
    }

    public async Task UpdatePlatoAsync(Plato plato)
    {
        var index = platos.FindIndex(p => p.Id == plato.Id);

        platos[index] = plato;
        await Task.CompletedTask;
    }


    public async Task DeletePlatoAsync(int id)
    {
        var plato = platos.FindIndex(p => p.Id == id);
        platos.RemoveAt(plato);
        await Task.CompletedTask;
    }
}
