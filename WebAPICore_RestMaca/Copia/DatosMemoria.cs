using WebAPICore_RestMaca.Entidades;
using WebAPICore_RestMaca.Repositorios;

namespace WebAPICore_RestMaca.Datos;

public class MemRepositorio 
{
    private List<Plato> platos = new List<Plato>(){
        new Plato { Id = 1, Nombre = "Sancocho de gallina", Descripcion = "Delicioso sancocho de gallina en memoria", Precio = 10000m, Imagen = "/Imagenes/chicken.jpg" },
        new Plato { Id = 2, Nombre = "Sancocho de pescado", Descripcion = "Delicioso sancocho de pescado en memoria", Precio = 20000m, Imagen = "/Imagenes/fisch.jpg" },
        new Plato { Id = 3, Nombre = "Sancocho de res", Descripcion = "Delicioso sancocho de res en memoria", Precio = 30000m, Imagen = "/Imagenes/beef.jpg" }
    };

    public void CreatePlato(Plato plato)
    {
        plato.Id = platos.Max(p => p.Id) + 1;
        platos.Add(plato);
    }

    public IEnumerable<Plato> GetAllPlatos()
    {
        return platos;
    }

    public Plato GetPlato(int id)
    {
        return platos.FirstOrDefault(p => p.Id == id) ?? throw new KeyNotFoundException($"Plato con id {id} no encontrado!");
    }

    public void UpdatePlato(Plato plato)
    {
        var platoExistente = platos.FirstOrDefault(p => p.Id == plato.Id);
        if (platoExistente == null)
        {
            throw new KeyNotFoundException($"Plato con id {plato.Id} no encontrado!");
        }
        platoExistente.Nombre = plato.Nombre;
        platoExistente.Descripcion = plato.Descripcion;
        platoExistente.Precio = plato.Precio;
        platoExistente.Imagen = plato.Imagen;
        platos[platos.IndexOf(platoExistente)] = platoExistente;
    }


    public void DeletePlato(int id)
    {
        var plato = platos.FirstOrDefault(p => p.Id == id);
        if (plato == null)
        {
            throw new KeyNotFoundException($"Plato con id {id} no encontrado!");
        }
        platos.Remove(plato);
    }
}
