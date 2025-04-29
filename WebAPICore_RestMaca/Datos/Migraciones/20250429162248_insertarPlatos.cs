using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebAPICore_RestMaca.Datos.Migraciones
{
    /// <inheritdoc />
    public partial class insertarPlatos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
            migrationBuilder.DeleteData(
                table: "Platos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Platos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Platos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Platos",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
