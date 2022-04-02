using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DisneyApi.AccessData.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Generos",
                columns: table => new
                {
                    GeneroId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Imagen = table.Column<string>(type: "varchar(2083)", unicode: false, maxLength: 2083, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.GeneroId);
                });

            migrationBuilder.CreateTable(
                name: "Personajes",
                columns: table => new
                {
                    PersonajeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Imagen = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    Peso = table.Column<int>(type: "int", nullable: false),
                    Historia = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personajes", x => x.PersonajeId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Peliculas",
                columns: table => new
                {
                    PeliculaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imagen = table.Column<string>(type: "varchar(2083)", unicode: false, maxLength: 2083, nullable: false),
                    Titulo = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "date", nullable: false),
                    Calificacion = table.Column<int>(type: "int", nullable: false),
                    GeneroId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peliculas", x => x.PeliculaId);
                    table.ForeignKey(
                        name: "FK_Peliculas_Generos_GeneroId",
                        column: x => x.GeneroId,
                        principalTable: "Generos",
                        principalColumn: "GeneroId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonajePeliculas",
                columns: table => new
                {
                    PersonajeId = table.Column<int>(type: "int", nullable: false),
                    PeliculaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonajePeliculas", x => new { x.PeliculaId, x.PersonajeId });
                    table.ForeignKey(
                        name: "FK_PersonajePeliculas_Peliculas_PeliculaId",
                        column: x => x.PeliculaId,
                        principalTable: "Peliculas",
                        principalColumn: "PeliculaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonajePeliculas_Personajes_PersonajeId",
                        column: x => x.PersonajeId,
                        principalTable: "Personajes",
                        principalColumn: "PersonajeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Generos",
                columns: new[] { "GeneroId", "Imagen", "Nombre" },
                values: new object[,]
                {
                    { 1, "Image here!", "Fantasy" },
                    { 2, "Image here!", "animation" }
                });

            migrationBuilder.InsertData(
                table: "Personajes",
                columns: new[] { "PersonajeId", "Edad", "Historia", "Imagen", "Nombre", "Peso" },
                values: new object[,]
                {
                    { 1, 94, "Mickey Mouse is a cartoon character created in 1928 by Walt Disney, and is the mascot of The Walt Disney Company. An anthropomorphic mouse who typically wears red shorts, large yellow shoes, and white gloves, Mickey is one of the world's most recognizable fictional characters", "Image here!", "Mickey Mouse", 10 },
                    { 2, 94, "Donald duck is an animated character created by Walt Disney as a foil to Mickey Mouse.[15] Making his screen debut in The Wise Little Hen on June 9, 1934, Donald is characterized as a pompous, showboating duck wearing a sailor suit, cap and a bow tie", "Image here!", "Minnie Mouse", 20 },
                    { 3, 18, "Anna of Arendelle is a fictional character who appears in Walt Disney Animation Studios' 53rd animated film Frozen (2013) and its sequel and 58th animated film Frozen II (2019). She is voiced by Kristen Bell as an adult. At the beginning of the film, Livvy Stubenrauch and Katie Lopez provide her speaking and singing voice as a young child, respectively. Agatha Lee Monn portrayed her as a nine-year-old (singing)", "Image here!", "Anna", 50 },
                    { 4, 21, "Elsa of Arendelle is a fictional character who appears in Walt Disney Animation Studios' 53rd animated film Frozen (2013) and its sequel and 58th animated film Frozen II (2019). She is voiced mainly by Broadway actress and singer Idina Menzel, with Eva Bella as a young child and by Spencer Ganus as a teenager in Frozen", "Image here!", "Elsa", 55 },
                    { 5, 89, "Goofy is an animated character that first appeared in 1932's Mickey's Revue.He  is predominately known for his slapstick style of comedy, and regularly appears alongside his best friends Mickey Mouse and Donald Duck", "Image here!", "Goofy", 70 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "Password", "RoleId", "Username" },
                values: new object[,]
                {
                    { 1, "Alkymer@alkemy.com", "1234", 1, "Alkymer" },
                    { 2, "test@test.com", "test", 2, "Test" },
                    { 3, "test2@test.com", "test", 2, "Test2" }
                });

            migrationBuilder.InsertData(
                table: "Peliculas",
                columns: new[] { "PeliculaId", "Calificacion", "FechaCreacion", "GeneroId", "Imagen", "Titulo" },
                values: new object[] { 1, 4, new DateTime(2004, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Image here!", "Mickey, Donald, Goofy: The Three Musketeers" });

            migrationBuilder.InsertData(
                table: "Peliculas",
                columns: new[] { "PeliculaId", "Calificacion", "FechaCreacion", "GeneroId", "Imagen", "Titulo" },
                values: new object[] { 2, 5, new DateTime(2013, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Image here!", "Frozen" });

            migrationBuilder.InsertData(
                table: "Peliculas",
                columns: new[] { "PeliculaId", "Calificacion", "FechaCreacion", "GeneroId", "Imagen", "Titulo" },
                values: new object[] { 3, 3, new DateTime(1929, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Image here!", "The Karnival Kid" });

            migrationBuilder.InsertData(
                table: "PersonajePeliculas",
                columns: new[] { "PeliculaId", "PersonajeId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 5 },
                    { 2, 3 },
                    { 2, 4 },
                    { 3, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Peliculas_GeneroId",
                table: "Peliculas",
                column: "GeneroId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonajePeliculas_PersonajeId",
                table: "PersonajePeliculas",
                column: "PersonajeId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonajePeliculas");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Peliculas");

            migrationBuilder.DropTable(
                name: "Personajes");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Generos");
        }
    }
}
