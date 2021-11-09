using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace entrevista.Migrations
{
    public partial class s1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fechas",
                table: "Curso");

            migrationBuilder.CreateTable(
                name: "Fecha",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<DateTime>(nullable: false),
                    Cursoid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fecha", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fecha_Curso_Cursoid",
                        column: x => x.Cursoid,
                        principalTable: "Curso",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fecha_Cursoid",
                table: "Fecha",
                column: "Cursoid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fecha");

            migrationBuilder.AddColumn<string>(
                name: "fechas",
                table: "Curso",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
