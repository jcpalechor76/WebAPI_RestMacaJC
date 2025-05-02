using System;
using WebAPICore_RestMaca.Entidades;

namespace WebAPICore_RestMaca.Repositorios;

public interface IPlatosRepositorio
{
    Task CreatePlatoAsync(Plato plato);

    Task<IEnumerable<Plato>> GetAllPlatosAsync();

    Task<Plato?> GetPlatoAsync(int id);

    
    Task UpdatePlatoAsync(Plato plato);

    Task DeletePlatoAsync(int id); 
}
