using Microsoft.EntityFrameworkCore;
using WebAPICore_RestMaca.Datos;
using WebAPICore_RestMaca.Entidades;

namespace WebAPICore_RestMaca.Repositorios;

public class EFRepositorio : IPlatosRepositorio
{
    private readonly AppDBContext _context;

    public EFRepositorio(AppDBContext context)
    {
        _context = context;
    }

    public async Task CreatePlatoAsync(Plato plato)
    {
        _context.Platos.Add(plato);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Plato>> GetAllPlatosAsync ()
    {
        return await _context.Platos.AsNoTracking().ToListAsync();
    }

    public async Task<Plato?> GetPlatoAsync(int id)
    {
        return await _context.Platos.FindAsync(id) ;
    }

    public async Task UpdatePlatoAsync(Plato plato)
    {
        _context.Update(plato);
        await _context.SaveChangesAsync();
    }

    public async Task DeletePlatoAsync(int id)
    {
        await _context.Platos.Where(p => p.Id == id).ExecuteDeleteAsync();
    }
}
