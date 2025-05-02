using Microsoft.EntityFrameworkCore;
using WebAPICore_RestMaca.Datos;
using WebAPICore_RestMaca.EndPoints;
using WebAPICore_RestMaca.Repositorios;

var builder = WebApplication.CreateBuilder(args);

//? SQLite var cadenaConexion = builder.Configuration.GetConnectionString("ConexionSQLLite");

//? 1 Servicios
//builder.Services.AddSingleton<IPlatosRepositorio,DatosMemoria>();
builder.Services.AddScoped<IPlatosRepositorio,EFRepositorio>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//? SQLite builder.Services.AddSqlite<AppDBContext>(cadenaConexion);
//? 1 Fin servicios

//? 2 Conexion a SQL Server
var cadenaConexion= builder.Configuration.GetConnectionString("ConexionSQLServer");
builder.Services.AddSqlServer<AppDBContext>(cadenaConexion);
//? 2 

var app = builder.Build();

//? 3 Migrar la base de datos al iniciar la aplicacion incluyendo la creacion de la base de datos si no existe y transacciones
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDBContext>();
    await dbContext.Database.MigrateAsync();
}
//? 3 Fin migracion

app.MapPlatosEndPoints();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//? SQLite await app.MigrateDBAsync();
//prueba de migracion
app.Run();