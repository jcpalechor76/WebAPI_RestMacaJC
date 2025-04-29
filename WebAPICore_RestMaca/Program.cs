using WebAPICore_RestMaca.EndPoints;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapPlatosEndPoints();

app.Run();

