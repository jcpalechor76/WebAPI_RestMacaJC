using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebAPICore_RestMaca.Datos.Migraciones
{
    /// <inheritdoc />
    public partial class crearPlatosSQLS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Platos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: false),
                    Imagen = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platos", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Platos",
                columns: new[] { "Id", "Descripcion", "Imagen", "Nombre", "Precio" },
                values: new object[,]
                {
                    { 1, "Delicioso sancocho de gallina con yuca, plátano y mazorca", "/Imagenes/chicken.jpg", "Sancocho de gallina", 15000m },
                    { 2, "Delicioso sancocho de pescado con yuca, plátano y mazorca", "/Imagenes/fish.jpg", "Sancocho de pescado", 15000m },
                    { 3, "Delicioso sancocho de res con yuca, plátano y mazorca", "/Imagenes/beef.jpg", "Sancocho de res", 15000m },
                    { 4, "Delicioso sancocho de gallina,pescado y res", "/Imagenes/varius.jpg", "Sancocho trifasico", 15000m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Platos");
        }
    }
}
