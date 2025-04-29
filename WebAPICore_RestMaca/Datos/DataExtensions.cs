using System;
using Microsoft.EntityFrameworkCore;

namespace WebAPICore_RestMaca.Datos;

public static class DataExtensions
{
    public static void MigrateDB(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var servicioDB = scope.ServiceProvider.GetRequiredService<AppDBContext>();
        servicioDB.Database.Migrate();
    }
}
