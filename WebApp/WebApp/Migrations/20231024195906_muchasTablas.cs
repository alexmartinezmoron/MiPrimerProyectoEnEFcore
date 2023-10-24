using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class muchasTablas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Pelicula",
                table: "Pelicula");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Actor",
                table: "Actor");

            migrationBuilder.RenameTable(
                name: "Pelicula",
                newName: "Peliculas");

            migrationBuilder.RenameTable(
                name: "Actor",
                newName: "Actores");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Peliculas",
                table: "Peliculas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Actores",
                table: "Actores",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Comentarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Contenido = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Recomendar = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentarios", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comentarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Peliculas",
                table: "Peliculas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Actores",
                table: "Actores");

            migrationBuilder.RenameTable(
                name: "Peliculas",
                newName: "Pelicula");

            migrationBuilder.RenameTable(
                name: "Actores",
                newName: "Actor");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pelicula",
                table: "Pelicula",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Actor",
                table: "Actor",
                column: "Id");
        }
    }
}
