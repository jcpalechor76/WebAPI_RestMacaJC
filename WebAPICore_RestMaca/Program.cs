using WebAPICore_RestMaca.Datos;
using WebAPICore_RestMaca.EndPoints;

var builder = WebApplication.CreateBuilder(args);
//var cadenaConexion = "Data Source=PlatosDB.db";

var cadenaConexion = builder.Configuration.GetConnectionString("ConexionSQLLite");

//? 1 Servicios
builder.Services.AddSqlite<AppDBContext>(cadenaConexion);
//? 1 Fin servicios

var app = builder.Build();

app.MapPlatosEndPoints();

app.MigrateDB();

app.Run();

