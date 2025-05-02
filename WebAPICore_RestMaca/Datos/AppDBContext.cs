using Microsoft.EntityFrameworkCore;
using WebAPICore_RestMaca.Entidades;

namespace WebAPICore_RestMaca.Datos;

public class AppDBContext : DbContext
{
    public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }            
    
    public DbSet<Plato> Platos => Set<Plato>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Plato>().HasData(

            new { Id = 1, Nombre = "Sancocho de gallina", Descripcion = "Delicioso sancocho de gallina con yuca, plátano y mazorca", Precio = 15000m, Imagen = "/Imagenes/chicken.jpg" },
            new { Id = 2, Nombre = "Sancocho de pescado", Descripcion = "Delicioso sancocho de pescado con yuca, plátano y mazorca", Precio = 15000m, Imagen = "/Imagenes/fish.jpg" },
            new { Id = 3, Nombre = "Sancocho de res", Descripcion = "Delicioso sancocho de res con yuca, plátano y mazorca", Precio = 15000m, Imagen = "/Imagenes/beef.jpg" },
            new { Id = 4, Nombre = "Sancocho trifasico", Descripcion = "Delicioso sancocho de gallina,pescado y res", Precio = 15000m, Imagen = "/Imagenes/varius.jpg" }
        );
    }
}