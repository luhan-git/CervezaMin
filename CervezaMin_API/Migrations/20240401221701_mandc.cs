using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CervezaMin_API.Migrations
{
    /// <inheritdoc />
    public partial class mandc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Marcas",
                columns: table => new
                {
                    IdMarca = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Empresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marcas", x => x.IdMarca);
                });

            migrationBuilder.CreateTable(
                name: "Cervezas",
                columns: table => new
                {
                    IdCerveza = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdMarca = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreImagen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrlImagen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Precio = table.Column<double>(type: "float", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    EsActivo = table.Column<bool>(type: "bit", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cervezas", x => x.IdCerveza);
                    table.ForeignKey(
                        name: "FK_Cervezas_Marcas_IdMarca",
                        column: x => x.IdMarca,
                        principalTable: "Marcas",
                        principalColumn: "IdMarca",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Marcas",
                columns: new[] { "IdMarca", "Empresa", "FechaActualizacion", "FechaCreacion", "Nombre" },
                values: new object[,]
                {
                    { 1, "AB InBev", new DateTime(2024, 4, 1, 17, 17, 1, 345, DateTimeKind.Local).AddTicks(404), new DateTime(2024, 4, 1, 17, 17, 1, 345, DateTimeKind.Local).AddTicks(390), "Cusqueña" },
                    { 2, "Backus", new DateTime(2024, 4, 1, 17, 17, 1, 345, DateTimeKind.Local).AddTicks(408), new DateTime(2024, 4, 1, 17, 17, 1, 345, DateTimeKind.Local).AddTicks(407), "Cristal" },
                    { 3, "Backus", new DateTime(2024, 4, 1, 17, 17, 1, 345, DateTimeKind.Local).AddTicks(411), new DateTime(2024, 4, 1, 17, 17, 1, 345, DateTimeKind.Local).AddTicks(410), "Pilsen callao" }
                });

            migrationBuilder.InsertData(
                table: "Cervezas",
                columns: new[] { "IdCerveza", "EsActivo", "FechaActualizacion", "FechaCreacion", "IdMarca", "Nombre", "NombreImagen", "Precio", "Stock", "UrlImagen" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2024, 4, 1, 17, 17, 1, 345, DateTimeKind.Local).AddTicks(580), new DateTime(2024, 4, 1, 17, 17, 1, 345, DateTimeKind.Local).AddTicks(579), 1, "Cusqueña Dorada", "CusqueñaDorada", 12.0, 1, "https://srv.com/cervezasMin/cusqueñaDorada.webp" },
                    { 2, true, new DateTime(2024, 4, 1, 17, 17, 1, 345, DateTimeKind.Local).AddTicks(585), new DateTime(2024, 4, 1, 17, 17, 1, 345, DateTimeKind.Local).AddTicks(584), 1, "Cusqueña Negra", "CusqueñaNegra", 15.0, 1, "https://srv.com/cervezasMin/cusqueñaNegra.webp" },
                    { 3, true, new DateTime(2024, 4, 1, 17, 17, 1, 345, DateTimeKind.Local).AddTicks(588), new DateTime(2024, 4, 1, 17, 17, 1, 345, DateTimeKind.Local).AddTicks(588), 1, "Cusqueña Trigo", "CusqueñaTrigo", 15.0, 1, "https://srv.com/cervezasMin/cusqueñaTrigo.webp" },
                    { 4, true, new DateTime(2024, 4, 1, 17, 17, 1, 345, DateTimeKind.Local).AddTicks(592), new DateTime(2024, 4, 1, 17, 17, 1, 345, DateTimeKind.Local).AddTicks(591), 2, "Cristal Rubia", "CristalRubia", 15.0, 1, "https://srv.com/cervezasMin/cristalrubia.webp" },
                    { 5, true, new DateTime(2024, 4, 1, 17, 17, 1, 345, DateTimeKind.Local).AddTicks(596), new DateTime(2024, 4, 1, 17, 17, 1, 345, DateTimeKind.Local).AddTicks(594), 3, "Pilsen Callao", "Pilsen Callao", 15.0, 1, "https://srv.com/cervezasMin/pilsenCallao.webp" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cervezas_IdMarca",
                table: "Cervezas",
                column: "IdMarca");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cervezas");

            migrationBuilder.DropTable(
                name: "Marcas");
        }
    }
}
