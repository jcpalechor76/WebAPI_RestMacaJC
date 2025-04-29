using System;
using Microsoft.EntityFrameworkCore;

namespace WebAPICore_RestMaca.Datos;

public static class DataExtensions
{
    public static async Task MigrateDBAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var servicioDB = scope.ServiceProvider.GetRequiredService<AppDBContext>();
        await servicioDB.Database.MigrateAsync();
    }
}
